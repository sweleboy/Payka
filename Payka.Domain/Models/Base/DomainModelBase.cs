using Payka.Domain.Exceptions;
using Payka.Domain.Rules;

namespace Payka.Domain.Models.Base;

public abstract class DomainModelBase
{
	public Guid Id
	{
		get;
		protected set;
	}
	public bool IsDeleted
	{
		get;
		protected set;
	}

	protected static void CheckRule(IBusinessRule rule)
	{
		if (rule.IsFailure())
		{
			throw new BusinessRuleValidationException(rule);
		}
	}
}