using System.Reflection;

namespace SampleRulePattern;

public class DiscountEngine
{
    private readonly IEnumerable<IDiscountRule> _rules;

    public DiscountEngine()
    {
        _rules = GetRules();
    }

    private IEnumerable<IDiscountRule> GetRules()
    {
        var type = typeof(IDiscountRule);

        var rules = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(x => type.IsAssignableFrom(x) && !x.IsInterface)
            .Select(x => (IDiscountRule)Activator.CreateInstance(x)!)
            .OrderBy(o => o.Type)
            .ToList();
        return rules;
    }

    public decimal Run(Customer customer)
    {
        var discount = 0m;
        foreach (var rule in _rules)
        {
            discount = rule.Apply(customer, discount);
            if (rule.IsStopped)
                return discount;
        }

        return discount;
    }
}