namespace ValueObjectHandsOn
{
    public class Money1 : ValueObjectWithReflection<Money1>
    {
        public decimal Value { get; set; }

        public Money1(decimal value)
        {
            Value = value;
        }
    }
}