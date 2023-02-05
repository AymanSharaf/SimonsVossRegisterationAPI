using Volo.Abp.Domain.Entities;

namespace SimmonsVoss.RegistrationApp.Features
{
    public class Feature : Entity<FeatureId>
    {
        public FeatureName Name { get; private set; }

        private Feature()
        {

        }

        public static Feature CreateNew(string name)
        {
            return new Feature()
            {
                Id = FeatureId.GenerateNew(),
                Name = new FeatureName(name),
            };
        }
    }
}
