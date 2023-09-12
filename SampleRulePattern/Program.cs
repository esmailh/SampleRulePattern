// See https://aka.ms/new-console-template for more information

using SampleRulePattern;

Console.WriteLine("Hello, World!");

var customer=new Customer
{
    Name = "esmailHatami",
    Plan = Plan.Internet,
    Years = 4,
    Coupon = new Coupon(0.05m)
};

var engine = new DiscountEngine();

var d = engine.Run(customer);

