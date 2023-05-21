using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ResponseService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseController : ControllerBase
    {
        //Get/api/response/100
        [Route("{id:int}")]
        [HttpGet]
        public  ActionResult GetAResponse(int id)
        {
            Random rnd = new Random();
            var rndInteger=rnd.Next(1,101);
            if (rndInteger>=id) 
            {
                Console.WriteLine("--> Failure-Generate a HTTP 500");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Console.WriteLine("--> Succes-Generate a HTTP 200");
            return Ok();
        }
    }
}
