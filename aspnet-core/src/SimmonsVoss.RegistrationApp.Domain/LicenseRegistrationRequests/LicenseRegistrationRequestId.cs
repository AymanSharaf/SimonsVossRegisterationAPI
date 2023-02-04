using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Values;

namespace SimmonsVoss.RegistrationApp.LicenseRegisterationRequests
{
    public class LicenseRegistrationRequestId : ValueObject
    {
        public Guid Id { get; set; }
        public static LicenseRegistrationRequestId GenerateNew()
        {
            return new LicenseRegistrationRequestId { Id = Guid.NewGuid() };
        }

        internal static LicenseRegistrationRequestId FromExisting(Guid guid)
        {
            return new LicenseRegistrationRequestId { Id = Guard.Against.Default(guid, "License Registeration Request Id") };
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Id;
        }
    }
}
