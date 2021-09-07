using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase 
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();
        //GET/api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands(); 
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        //GET/api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult <CommandReadDto> GetCommandById(int id) 
        {
            var CommandItem = _repository.GetCommandById(id);
            if(CommandItem != null) {
            return Ok(_mapper.Map<CommandReadDto>(CommandItem));
            }
            return NotFound();
        }

        //POST /api/commands
        [HttpPost]
        public ActionResult <CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto); 
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            return Ok(commandModel);
        } 

    }
}