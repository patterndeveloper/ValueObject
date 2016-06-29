using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ValueObjectHandsOn
{
    public abstract class ValueObjectWithReflection<T> : IEquatable<T> where T : ValueObjectWithReflection<T>
    {
        public bool Equals(T other)
        {
            var myFields = GetMyFields().Select(fi => fi.GetValue(this));
            var otherFields = other.GetMyFields().Select(fi => fi.GetValue(other));
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
            var fields = GetMyFields().Select(fi => fi.GetValue(this));
            var result = fields.Aggregate(1, (current, field) => current ^ field.GetHashCode());
            return result;
        }

        public static bool operator ==(ValueObjectWithReflection<T> first, ValueObjectWithReflection<T> second)
        {
            return Equals(first, second);
        }

        public static bool operator !=(ValueObjectWithReflection<T> first, ValueObjectWithReflection<T> second)
        {
            return !(first == second);
        }

        private IEnumerable<FieldInfo> GetMyFields()
        {
            var type = GetType();
            var fieldInfos = new List<FieldInfo>();

            while (type != typeof(object))
            {
                var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                fieldInfos.AddRange(fields);
                type = type.BaseType;
            }
            return fieldInfos;
        }
    }
}