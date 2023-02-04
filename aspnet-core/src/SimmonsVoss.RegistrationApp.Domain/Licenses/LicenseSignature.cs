using Ardalis.GuardClauses;
using System.Collections.Generic;
using Volo.Abp.Domain.Values;

namespace SimmonsVoss.RegistrationApp.Licenses
{
    public class LicenseSignature : ValueObject
    {
        public string Value { get; private set; }
        public LicenseSignature(string value)
        {
            Value = Guard.Against.NullOrEmpty(value);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
