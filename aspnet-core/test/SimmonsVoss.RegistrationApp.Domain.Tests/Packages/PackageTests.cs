using Shouldly;
using SimmonsVoss.RegistrationApp.Features;
using System;
using System.Collections.Generic;
using Xunit;

namespace SimmonsVoss.RegistrationApp.Packages
{
    public class PackageTests
    {
        public PackageTests()
        {

        }

        [Fact]
        public void Should_Create_Package_Successfully()
        {
            var packageName = "Package Name";
            List<Feature> features = new List<Feature>() { Feature.CreateNew("FristFeature") };

            var package = Package.CreateNew(packageName, features);

            package.ShouldNotBeNull();
            package.Name.ShouldNotBeNull().Value.ShouldNotBeNullOrEmpty();
            package.Id.ShouldNotBeNull();
            package.Features.ShouldNotBeNull();
        }

        [Fact]
        public void Should_Fail_To_Create_Package_If_Name_Is_Empty()
        {
            var packageName = "";
            List<Feature> features = new List<Feature>() { Feature.CreateNew("FristFeature") };

            Should.Throw<ArgumentException>(() =>
            {
                Package.CreateNew(packageName, features);
            });

        }


        [Fact]
        public void Should_Add_Feature_To_Package_Successfully()
        {
            var packageName = "Package Name";
            List<Feature> features = new List<Feature>() { Feature.CreateNew("FristFeature") };
            var package = Package.CreateNew(packageName, features);
            var newFeature = Feature.CreateNew("NewFeature");

            package.AddFeature(newFeature);

            Assert.Contains(package.Features, feature => feature.Equals(feature));
        }
    }
}
