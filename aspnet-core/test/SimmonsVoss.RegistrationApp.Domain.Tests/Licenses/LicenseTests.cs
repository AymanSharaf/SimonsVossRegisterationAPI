using Shouldly;
using SimmonsVoss.RegistrationApp.Packages;
using System;
using Xunit;

namespace SimmonsVoss.RegistrationApp.Licenses
{
    public class LicenseTests
    {
        [Fact]
        public void Should_Create_License_Successfully()
        {
            var packageId = PackageId.GenerateNew();
            var key = "123-das-12312-aqy";

            var license = License.CreateNew(key, packageId);

            license.ShouldNotBeNull();
            license.Status.ShouldBe(LicenseStatus.New);
            license.LicenseKey.Value.ShouldBeEquivalentTo(key);
        }

        [Fact]
        public void Should_Create_License_Fail_If_InvalidKey()
        {
            var packageId = PackageId.GenerateNew();
            var key = "";

            Should.Throw<ArgumentException>(() =>
            {
                License.CreateNew(key, packageId);
            });
        }

        [Fact]
        public void Should_Sign_License_Successfully()
        {
            var license = License.CreateNew("123-das-12312-aqy", PackageId.GenerateNew());

            license.Sign("signature");

            license.Status.ShouldBe(LicenseStatus.Active);
            license.Signature.Value.ShouldBeEquivalentTo("signature");
        }

        [Fact]
        public void Should_Sign_License_Fail_If_InvalidSignature()
        {
            var license = License.CreateNew("123-das-12312-aqy", PackageId.GenerateNew());



            Should.Throw<ArgumentException>(() =>
            {
                license.Sign("");
            });
        }
    }
}
