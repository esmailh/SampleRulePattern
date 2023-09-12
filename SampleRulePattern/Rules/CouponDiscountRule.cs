namespace SampleRulePattern.Rules;

public class CouponDiscountRule : IDiscountRule
{
    private bool _isStopped = false;
    public DiscountRule Type => DiscountRule.CouponDiscountRule;
    public bool IsStopped => _isStopped;


    public decimal Apply(Customer customer, decimal currentDiscount)
    {
        var result = 0m;
        if (customer.Years < 5)
            result= customer.Coupon.Discount + currentDiscount > 0.2m
                ? 0.2m
                : customer.Coupon.Discount + currentDiscount;
        
        result= customer.Coupon.Discount + currentDiscount > 0.2m
            ? 0.25m
            : customer.Coupon.Discount + currentDiscount;
        
        if(result is not Decimal.Zero)
            _isStopped = true;

        return result;
    }
}