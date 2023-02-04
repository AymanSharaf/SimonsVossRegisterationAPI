using Shouldly;
using System;
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
            var featureName = "New Feature";
            var feature = Feature.CreateNew(featureName);

            feature.ShouldNotBeNull();
            feature.Id.Id.ShouldNotBe(Guid.Empty);
            feature.Name.ShouldNotBeNull();
            feature.Name.Value.ShouldBe(featureName);


        }

        [Fact]
        public void Should_Fail_If_FeatureName_Is_Empty()
        {
            Should.Throw<ArgumentException>(() =>
            {
                Feature.CreateNew("");
            });
        }
    }
}
