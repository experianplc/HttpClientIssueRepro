namespace TestClientApp.Controllers
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private static HttpClient client = new HttpClient();
        private readonly ILogger logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            try
            {
                using (var response = await client.GetAsync("<url>"))
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (TaskCanceledException ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
            
        }
    }
}
