using SimmonsVoss.RegistrationApp.Features;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Entities;

namespace SimmonsVoss.RegistrationApp.Packages
{
    public class Package : Entity<PackageId>
    {
        public PackageName Name { get; private set; }

        private List<Feature> _features;
        public IReadOnlyList<Feature> Features => _features;

        private Package()
        {
            _features = new List<Feature>();
        }

        public static Package CreateNew(string name, List<Feature> features)
        {
            var package = new Package()
            {
                Id = PackageId.GenerateNew(),
                Name = new PackageName(name),
            };

            features?.ForEach(feature =>
            {
                package.AddFeature(feature);
            });

            return package;
        }

        public void AddFeature(Feature feature)
        {
            var isFeatureAlreadyUsedInPackage = _features.Any(f => f.Equals(feature));

            if (!isFeatureAlreadyUsedInPackage)
            {
                _features.Add(feature);
            }
        }
    }
}
