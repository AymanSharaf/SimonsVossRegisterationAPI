using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Values;

namespace SimmonsVoss.RegistrationApp.Packages
{
    public class PackageId : ValueObject
    {
        public Guid Id { get; private set; }

        internal static PackageId GenerateNew()
        {
            return new PackageId { Id = Guid.NewGuid() };
        }

        internal static PackageId FromExisting(Guid guid)
        {
            return new PackageId { Id = Guard.Against.Default(guid, "Package Id") };
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Id;
        }
    }
}
