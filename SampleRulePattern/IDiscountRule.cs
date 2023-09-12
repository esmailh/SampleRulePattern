namespace SampleRulePattern;

public interface IDiscountRule
{
    public DiscountRule Type { get; }
    public bool IsStopped { get; }
    decimal Apply(Customer customer, decimal currentDiscount);
}

public enum DiscountRule:short
{
    PlanDiscountRule=0,
    LoyaltyDiscountRule=1,
    CouponDiscountRule=2
}