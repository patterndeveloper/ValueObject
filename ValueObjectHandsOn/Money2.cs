using System.Collections.Generic;

namespace ValueObjectHandsOn
{
    public class Money2 : ValueObjectWhitoutReflection<Money2>
    {
        public decimal Value { get; set; }
        protected override IEnumerable<object> GetFields()
        {
            return new List<object>() { Value };
        }

        public Money2(decimal value)
        {
            Value = value;
        }
    }
}