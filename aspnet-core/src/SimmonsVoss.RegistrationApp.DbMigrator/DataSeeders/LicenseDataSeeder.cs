using SimmonsVoss.RegistrationApp.Licenses;
using SimmonsVoss.RegistrationApp.Packages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace SimmonsVoss.RegistrationApp.DbMigrator.DataSeeders
{
    internal class LicenseDataSeeder : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Package> _packageRepository;
        private readonly IRepository<License> _licenseRepository;

        public LicenseDataSeeder(IRepository<Package> packageRepository,
                                 IRepository<License> licenseRepository)
        {
            _packageRepository = packageRepository;
            _licenseRepository = licenseRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            // throw new NotImplementedException();
            var packages = await _packageRepository.GetListAsync();

            foreach (var package in packages)
            {
                var licenses = new List<License>();

                for (int i = 0; i < 100; i++)
                {
                    licenses.Add(License.CreateNew($"key{i}", package.Id));
                }

                await _licenseRepository.InsertManyAsync(licenses, true);
            }
        }
    }
}
