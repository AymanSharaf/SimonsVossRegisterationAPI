using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Values;

namespace SimmonsVoss.RegistrationApp.Features
{
    public class FeatureId : ValueObject
    {
        public Guid Id { get; private set; }

        internal static FeatureId GenerateNew()
        {
            return new FeatureId { Id = Guid.NewGuid() };
        }

        internal static FeatureId FromExisting(Guid guid)
        {
            return new FeatureId { Id = Guard.Against.Default(guid, "Feature Id") };
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Id;
        }
    }
}
