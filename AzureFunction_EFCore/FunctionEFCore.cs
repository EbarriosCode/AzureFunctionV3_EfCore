using AzureFunction_EFCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AzureFunction_EFCore
{
    public class FunctionEFCore
    {
        private readonly IAlbumService _albumService;

        public FunctionEFCore(IAlbumService albumService) => _albumService = albumService;

        [FunctionName("FunctionEFCore")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            
            var albumes = await _albumService.GetAsync();
            return new OkObjectResult(albumes);
        }
    }
}
