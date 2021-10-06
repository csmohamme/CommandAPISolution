using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CommandAPI.Data;
using CommandAPI.Models;
using AutoMapper;
using CommandAPI.Dtos;

namespace CommandAPI.Contrllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CommandsController : ControllerBase
    {
        private readonly ICommandAPIRepo _respository;
        private readonly IMapper _mapper;

        public CommandsController(ICommandAPIRepo repository, IMapper mapper)
        {
            _respository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _respository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        [HttpGet("{id}")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _respository.GetCommandById(id);
            if (commandItem == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CommandReadDto>(commandItem));
        }
    }
}