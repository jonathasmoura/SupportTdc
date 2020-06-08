using System;
using Flunt.Notifications;
using td_corp.DOMAIN.Commands.MarkingCommands;
using td_corp.DOMAIN.CommandsResults;
using td_corp.DOMAIN.Entities;
using td_corp.DOMAIN.Repositories;
using td_corp.SHARED;
using td_corp.SHARED.Interfaces;

namespace td_corp.DOMAIN.MarkingCommandHandlers
{
    public class MarkingCommandHandler : Notifiable, ICommandHandler<CreateMarkingCommand>
    {
        private readonly IMarkingRepository _markingREpository;
        public ICommandResult Handle(CreateMarkingCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandsResult(false, "Ops, não foi possível realizar registro da marca!", command.Notifications);

            if (_markingREpository.MarkingExists(command.Name))
                return new CommandsResult(false, "A marca informada já está cadastrada em nossa base de dados", command);

            var entity = new Marking(command.Name);

            AddNotifications(entity.Notifications);
            if (Invalid)
                return new CommandsResult(false, "Ops, não possivel cadastrar a marca", command);

                 _markingREpository.CreateMarking(entity);

                 return new CommandsResult(true, "Marca registrada com sucesso!!!", entity);
        }
    }
}
