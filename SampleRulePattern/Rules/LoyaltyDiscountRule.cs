namespace SampleRulePattern.Rules;

public class LoyaltyDiscountRule : IDiscountRule
{
    private bool _isStopped = false;
    public DiscountRule Type => DiscountRule.LoyaltyDiscountRule;
    public bool IsStopped => _isStopped;

    public decimal Apply(Customer customer, decimal currentDiscount)
    {
        var result= customer.Years > 3 ? currentDiscount + 0.05m : currentDiscount;
        if(result is not Decimal.Zero)
            _isStopped = true;
        return result;
    }
}