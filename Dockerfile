FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Build.props", "."]
COPY ["Directory.Packages.props", "."]
COPY ["Payka.API/Payka.API.csproj", "Payka.API/"]
COPY ["Payka.Application/Payka.Application.csproj", "Payka.Application/"]
COPY ["Payka.Dal/Payka.Dal.csproj", "Payka.Dal/"]
COPY ["Payka.Domain/Payka.Domain.csproj", "Payka.Domain/"]
RUN dotnet restore "Payka.API/Payka.API.csproj"
COPY . .
WORKDIR "/src/Payka.API"
RUN dotnet build "Payka.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Payka.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Payka.API.dll"]
