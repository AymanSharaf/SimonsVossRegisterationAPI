using Ardalis.GuardClauses;
using System.Collections.Generic;
using Volo.Abp.Domain.Values;

namespace SimmonsVoss.RegistrationApp.Features
{
    public class FeatureName : ValueObject
    {
        public string Value { get; private set; }

        public FeatureName(string value)
        {
            Value = Guard.Against.NullOrEmpty(value, "Feature Name");
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
