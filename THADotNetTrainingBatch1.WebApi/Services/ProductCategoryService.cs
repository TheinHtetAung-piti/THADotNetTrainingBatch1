using THADotNetTrainingBatch1.Shared;

namespace THADotNetTrainingBatch1.WebApi.Services
{
    public class ProductCategoryService
    {
        private readonly IConfiguration _configuration;
        private readonly IDbV2Service dbService;
        public ProductCategoryService(IConfiguration configuration, IDbV2Service dbService)
        {
            _configuration = configuration;
            this.dbService = dbService;
        }
    }
}
