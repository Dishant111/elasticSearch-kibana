using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace elasticSearchAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> logger;

        public TestController(ILogger<TestController> logger )
        {
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var rng = new Random();
                if (rng.Next(0,5) < 2)
                {
                    throw new Exception("opps something not working");
                }
                else 
                {
                    return Ok(
                        Enumerable.Range(0,5).Select(x=>new { 
                            Date = DateTime.Now.AddDays(x),
                            x = x.ToString()
                        })
                        );
                }        


            }
            catch (Exception e)
            {
                logger.LogError(e,"some thind is ot right");
                return new StatusCodeResult(500);
            }
        }
    }
}
