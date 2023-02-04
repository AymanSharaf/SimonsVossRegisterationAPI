using Ardalis.GuardClauses;
using System.Collections.Generic;
using Volo.Abp.Domain.Values;

namespace SimmonsVoss.RegistrationApp.LicenseRegisterationRequests
{
    public class ComapnyName : ValueObject
    {
        public string Value { get; private set; }
        public ComapnyName(string value)
        {
            Value = Guard.Against.NullOrEmpty(value);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
