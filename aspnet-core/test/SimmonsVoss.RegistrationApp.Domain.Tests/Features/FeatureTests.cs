using Shouldly;
using Xunit;

namespace SimmonsVoss.RegistrationApp.Features
{
    public class FeatureTests //: RegistrationAppDomainTestBase
    {
        public FeatureTests()
        {

        }

        [Fact]
        public void Should_Create_Valid_Feature()
        {
            var feature = Feature.CreateNew("New Feature");

            feature.ShouldNotBeNull();
            feature.Id.ShouldNotBeNull();
            feature.Name.ShouldNotBeNull();


        }
    }
}
