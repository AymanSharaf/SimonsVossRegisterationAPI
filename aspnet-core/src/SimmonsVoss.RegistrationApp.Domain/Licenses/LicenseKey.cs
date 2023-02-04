using Ardalis.GuardClauses;
using System.Collections.Generic;
using Volo.Abp.Domain.Values;

namespace SimmonsVoss.RegistrationApp.Licenses
{
    public class LicenseKey : ValueObject
    {
        public string Value { get; private set; }
        public LicenseKey(string key)
        {
            Value = Guard.Against.NullOrEmpty(key); // Should also check for valid format
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
