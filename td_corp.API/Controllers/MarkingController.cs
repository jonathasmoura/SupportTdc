using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using td_corp.DOMAIN.Commands.MarkingCommands;
using td_corp.DOMAIN.CommandsResults;
using td_corp.DOMAIN.Entities;
using td_corp.DOMAIN.MarkingCommandHandlers;
using td_corp.DOMAIN.Repositories;

namespace td_corp.API.Controllers
{
    [ApiController]
    [Route("v1/marcas")]
    public class MarkingController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IEnumerable<Marking> GetAllMarkings([FromServices] IMarkingRepository marckingRepository)
        {
            return marckingRepository.GetAll();
        }

        [Route("")]
        [HttpPost]
        public CommandsResult CreateMarking([FromBody] CreateMarkingCommand command, [FromServices] MarkingCommandHandler handler)
        {
            return (CommandsResult)handler.Handle(command);
        }

        [Route("{id}")]
        [HttpGet]
        public CommandsResult GetById([FromHeader] GetMarkingByIdCommand command, [FromServices] MarkingCommandHandler handler)
        {
            return (CommandsResult)handler.Handle(command);
        }

        [Route("inactivate/{id}")]
        [HttpPatch]
        public CommandsResult Inactivated([FromHeader] InactiveMarkingByIdCommand command, [FromServices] MarkingCommandHandler handler)
        {
            return (CommandsResult)handler.Handle(command);
        }

        [Route("activate/{id}")]
        [HttpPatch]
        public CommandsResult Activated([FromHeader] ActiveMarkingByIdCommand command, [FromServices] MarkingCommandHandler handler)
        {
            return (CommandsResult)handler.Handle(command);
        }

        [Route("{id}")]
        [HttpPut]
        public CommandsResult EditMarking([FromHeader] Guid id, [FromBody] EditMarkingCommand command, [FromServices] MarkingCommandHandler handler)
        {
            return (CommandsResult)handler.Handle(command);
        }
    }
}
