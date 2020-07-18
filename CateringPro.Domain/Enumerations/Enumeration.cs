using CateringPro.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CateringPro.Domain.Enumerations
{

    public class Enumeration : IComparable
    {

        #region - - - - - - Fields - - - - - -

        private readonly string m_Name;

        private readonly int m_Value;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        protected Enumeration() { }

        protected Enumeration(string name, int value)
        {
            this.m_Name = name;
            this.m_Value = value;
        }

        #endregion Constructors

        #region - - - - - - Methods - - - - - -

        public int CompareTo(object other)
            => this.m_Value.CompareTo(((Enumeration)other).Value);

        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration;

            if (otherValue == null)
                return false;

            var typeMatches = this.GetType().Equals(obj.GetType());
            var valueMatches = this.m_Value.Equals(otherValue.Value);

            return typeMatches && valueMatches;
        }

        public static T FromName<T>(string name) where T : Enumeration
        {
            if (name == null)
                return null;

            return GetAll<T>()
                    .SingleOrDefault(e => e.Name == name)
                        ?? throw new InvalidEnumException(name);
        }

        public static T FromValue<T>(int value) where T : Enumeration
            => GetAll<T>()
                    .SingleOrDefault(e => e.Value == value)
                        ?? throw new InvalidEnumException(value.ToString());


        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public |
                                             BindingFlags.Static |
                                             BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public override int GetHashCode()
            => this.m_Value.GetHashCode();

        public string Name
            => this.m_Name;

        public static implicit operator int(Enumeration enumeration)
            => enumeration.Value;

        public override string ToString()
            => this.Name;

        public int Value
            => this.m_Value;

        #endregion Methods

    }

}
