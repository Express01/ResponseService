using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RequestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        //Get api/request
        [HttpGet]
        public async Task<ActionResult> MakeRequest()
        {
          var client=new HttpClient();
            var response = await client.GetAsync("https://localhost:7213/api/Response/25");
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
