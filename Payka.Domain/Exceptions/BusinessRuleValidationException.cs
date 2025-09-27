using Payka.Domain.Rules;

namespace Payka.Domain.Exceptions;

public class BusinessRuleValidationException : Exception
{
	public IBusinessRule BrokenRule { get; }

	public BusinessRuleValidationException(IBusinessRule rule)
		: base(rule.Message)
	{
		BrokenRule = rule;
	}
}