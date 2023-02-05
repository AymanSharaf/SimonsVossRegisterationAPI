using SimmonsVoss.RegistrationApp.Features;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace SimmonsVoss.RegistrationApp.DbMigrator.DataSeeders
{
    public class FeaturesDataSeeders : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Feature> repository;

        public FeaturesDataSeeders(IRepository<Feature> repository)
        {
            this.repository = repository;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            var hasNoData = await repository.GetCountAsync() == 0;

            if (hasNoData)
            {
                var featruesList = new List<Feature>
                {
                    Feature.CreateNew("First Feature"),
                    Feature.CreateNew("Second Feature"),
                    Feature.CreateNew("Third Feature"),
                };

                await repository.InsertManyAsync(featruesList, true);
            }
        }
    }
}
