namespace SampleRulePattern.Rules;

public class PlanDiscountRule : IDiscountRule
{
    private bool _isStopped = false;
    public DiscountRule Type => DiscountRule.PlanDiscountRule;
    public bool IsStopped => _isStopped;

    public decimal Apply(Customer customer, decimal currentDiscount)
    {
        var result= customer.Plan is Plan.Internet or Plan.Phone 
            ? currentDiscount + 0.1m 
            : currentDiscount + 0.15m;
        if(result is not Decimal.Zero)
            _isStopped = true;
        return result;
    }
}