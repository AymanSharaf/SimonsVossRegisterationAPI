using SimmonsVoss.RegistrationApp.Features;
using SimmonsVoss.RegistrationApp.Packages;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace SimmonsVoss.RegistrationApp.DbMigrator.DataSeeders
{
    public class PackagesDataSeeder : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Package> _packageRepository;
        private readonly IRepository<Feature> _featuresRepository;

        public PackagesDataSeeder(IRepository<Package> packageRepository, IRepository<Feature> featuresRepository)
        {
            _packageRepository = packageRepository;
            _featuresRepository = featuresRepository;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            var hasNoData = await _packageRepository.GetCountAsync() == 0;

            if (hasNoData)
            {
                var features = await _featuresRepository.GetListAsync(); // could be null, totally dependant on sequence of execution
                var pacakge = Package.CreateNew("Starter Package", features);
                await _packageRepository.InsertAsync(pacakge, true);
            }
        }
    }
}
