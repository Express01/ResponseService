using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestService.Policies;

namespace RequestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
      
        private readonly IHttpClientFactory _clientFactory;

        public RequestController(ClientPolicy clientPolicy,IHttpClientFactory clientFactory)
        {
          
            _clientFactory = clientFactory;
        }
        //Get api/request
        [HttpGet]
        public async Task<ActionResult> MakeRequest()
        {
          //var client=new HttpClient();
          var client=_clientFactory.CreateClient("Test");
            var response = await client.GetAsync("https://localhost:7213/api/Response/25");
          //  var response = await _clientPolicy.ImmediateHttpRetry.ExecuteAsync(() => client.GetAsync("https://localhost:7213/api/Response/25"));
            if (response.IsSuccessStatusCode)
            {
                 Console.WriteLine("--> ResponseService returned Succes");
                return Ok();
            }
            Console.WriteLine("--> ResponseService returned Failure");
            return StatusCode(StatusCodes.Status500InternalServerError);

        }
    }
}
