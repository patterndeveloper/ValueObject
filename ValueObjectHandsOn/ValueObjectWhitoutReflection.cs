using System;
using System.Collections.Generic;
using System.Linq;

namespace ValueObjectHandsOn
{
    public abstract class ValueObjectWhitoutReflection<T> : IEquatable<T> where T : ValueObjectWhitoutReflection<T>
    {
        protected abstract IEnumerable<object> GetFields();

        public bool Equals(T other)
        {
            var myFields = GetFields();
            var otherFields = other.GetFields();
            return myFields.SequenceEqual(otherFields);
        }

        public override bool Equals(object other)
        {
            if (other == null)
                return false;
            var meAsT = other as T;
            if (meAsT == null)
                return false;
            return Equals(meAsT);
        }

        public override int GetHashCode()
        {
            return GetFields().Aggregate(1, (current, field) => current ^ field.GetHashCode());
        }

        public static bool operator ==(ValueObjectWhitoutReflection<T> first, ValueObjectWhitoutReflection<T> second)
        {
            return Equals(first, second);
        }

        public static bool operator !=(ValueObjectWhitoutReflection<T> first, ValueObjectWhitoutReflection<T> second)
        {
            return !(first == second);
        }
    }
}