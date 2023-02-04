using Ardalis.GuardClauses;
using System.Collections.Generic;
using Volo.Abp.Domain.Values;

namespace SimmonsVoss.RegistrationApp.Packages
{
    public class PackageName : ValueObject
    {
        public string Value { get; private set; }

        public PackageName(string value)
        {
            Value = Guard.Against.NullOrEmpty(value, "Package Name");
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
