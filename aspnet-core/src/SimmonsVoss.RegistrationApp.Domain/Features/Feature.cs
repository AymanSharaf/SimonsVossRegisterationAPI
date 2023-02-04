namespace SimmonsVoss.RegistrationApp.Features
{
    public class Feature
    {
        public FeatureId Id { get; private set; }
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
