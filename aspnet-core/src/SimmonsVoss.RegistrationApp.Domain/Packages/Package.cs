using SimmonsVoss.RegistrationApp.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Entities;

namespace SimmonsVoss.RegistrationApp.Packages
{
    public class Package : Entity<PackageId>
    {
        public PackageName Name { get; private set; }

        private List<FeatureId> _featureIds;
        public IReadOnlyList<FeatureId> FeatureIds => _featureIds;

        private Package()
        {
            _featureIds = new List<FeatureId>();
        }

        public static Package CreateNew(string name, List<Guid> featureIds)
        {
            var package = new Package()
            {
                Id = PackageId.GenerateNew(),
                Name = new PackageName(name),
            };

            featureIds?.ForEach(id =>
            {
                package.AddFeature(id);
            });

            return package;
        }

        public void AddFeature(Guid featureId)
        {
            var id = FeatureId.FromExisting(featureId);
            var isFeatureIdAlreadyUsedInPackage = _featureIds.Any(i => i.ValueEquals(id));

            if (!isFeatureIdAlreadyUsedInPackage)
            {
                _featureIds.Add(FeatureId.FromExisting(featureId));
            }
        }
    }
}
