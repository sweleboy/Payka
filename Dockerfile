FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY *.sln ./

COPY ["Payka.API/Payka.API.csproj", "Payka.API/"]
COPY ["Payka.Application/Payka.Application.csproj", "Payka.Application/"]
COPY ["Payka.Dal/Payka.Dal.csproj", "Payka.Dal/"]
#COPY ["Payka.Domain/Payka.Domain.csproj", "Payka.Domain/"]

RUN dotnet restore

COPY . .

WORKDIR "/src/Payka.API"
RUN dotnet build "Payka.API.csproj" -c Release -o /app/build

FROM build AS publish
WORKDIR "/src/Payka.API"
RUN dotnet publish "Payka.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Payka.API.dll"]