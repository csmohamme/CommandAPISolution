using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace CommandAPI.Contrllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get(){
            return new string[] {"this","is","hard","coded"};
        }
    }
}