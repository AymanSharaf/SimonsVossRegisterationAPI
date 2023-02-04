using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Values;

namespace SimmonsVoss.RegistrationApp.Licenses
{
    public class LicenseId : ValueObject
    {
        public Guid Id { get; set; }
        public static LicenseId GenerateNew()
        {
            return new LicenseId { Id = Guid.NewGuid() };
        }

        internal static LicenseId FromExisting(Guid guid)
        {
            return new LicenseId { Id = Guard.Against.Default(guid, "License Id") };
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Id;
        }
    }
}
