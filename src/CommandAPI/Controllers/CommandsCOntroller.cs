using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CommandAPI.Data;
using CommandAPI.Models;

namespace CommandAPI.Contrllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CommandsController : ControllerBase
    {
        private readonly ICommandAPIRepo _respository;
        public CommandsController(ICommandAPIRepo repository)
        {
            _respository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands(){
            var commandItems = _respository.GetAllCommands();
            return Ok(commandItems);
        }

        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id){
            var commandItem = _respository.GetCommandById(id);
            if(commandItem == null){
                return NotFound();
            }
            return Ok(commandItem);
        }
    }
}