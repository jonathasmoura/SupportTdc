using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using td_corp.DOMAIN.Commands.MarkingCommands.ModelCommands;
using td_corp.DOMAIN.CommandsResults;
using td_corp.DOMAIN.Entities;
using td_corp.DOMAIN.ModelCommandHandlers;
using td_corp.DOMAIN.Repositories;

namespace td_corp.API.Controllers
{
    [ApiController]
    [Route("v1/models")]
    public class ModelController : ControllerBase
    {
        [Route("")]
        public IEnumerable<Model> GetAll([FromServices] IModelRepository modelRepository)
        {
            return modelRepository.GetAll();
        }

        [Route("")]
        [HttpPost]
        public CommandsResult CreateModel([FromBody] CreateModelCommand command, [FromServices] ModelCommandHandler handler)
        {
            return (CommandsResult)handler.Handle(command);
        }

        [Route("{id}")]
        [HttpPut]
        public CommandsResult EditModel([FromHeader] Guid id, [FromBody] UpdateModelCommand command, [FromServices] ModelCommandHandler handler)
        {
            return (CommandsResult)handler.Handle(command);
        }
    }
}