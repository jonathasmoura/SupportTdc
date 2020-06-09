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
    public class MarkingCommandHandler : Notifiable,
    ICommandHandler<CreateMarkingCommand>,
    ICommandHandler<EditMarkingCommand>,
    ICommandHandler<GetMarkingByIdCommand>,
    ICommandHandler<InactiveMarkingByIdCommand>,
    ICommandHandler<ActiveMarkingByIdCommand>
    {
        private readonly IMarkingRepository _markingRepository;

        public MarkingCommandHandler(IMarkingRepository markingRepository)
        {
            _markingRepository = markingRepository;
        }
        public ICommandResult Handle(CreateMarkingCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandsResult(false, "Ops, não foi possível realizar registro da marca!", command.Notifications);

            if (_markingRepository.MarkingExists(command.Name))
                return new CommandsResult(false, "A marca informada já está cadastrada em nossa base de dados", command);

            var entity = new Marking(command.Name);

            AddNotifications(entity.Notifications);
            if (Invalid)
                return new CommandsResult(false, "Ops, não possivel cadastrar a marca", command);

            _markingRepository.CreateMarking(entity);

            return new CommandsResult(true, "Marca registrada com sucesso!!!", entity);
        }

        public ICommandResult Handle(EditMarkingCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandsResult(false, "Ops, não foi possível localizar o registro.", command.Notifications);

            var mark = _markingRepository.GetById(command.Id);
            mark.UpdateName(command.Name);

            _markingRepository.UpdateMarking(mark);

            return new CommandsResult(true, "Marca atualizada com sucesso!!!", mark);
        }

        public ICommandResult Handle(GetMarkingByIdCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandsResult(false, "Ops, não foi possivel buscar seu registro!", command.Notifications);

            var mark = _markingRepository.GetById(command.Id);
            return new CommandsResult(true, "Marca retornada com sucesso!!!", mark);
        }

        public ICommandResult Handle(InactiveMarkingByIdCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandsResult(false, "Ops, não foi possível localizar seu registro", command.Notifications);

            var mark = _markingRepository.GetById(command.Id);
            mark.Inactivate();
            mark.InactivationDate = DateTime.Now;

            _markingRepository.UpdateMarking(mark);

            return new CommandsResult(true, "Marca desativada com sucesso!!!", mark);
        }

        public ICommandResult Handle(ActiveMarkingByIdCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandsResult(false, "Ops, não foi possível localizar o seu registro", command.Notifications);

            var mark = _markingRepository.GetById(command.Id);
            mark.Activate();
            mark.ActivationDate = DateTime.Now;

            _markingRepository.UpdateMarking(mark);

            return new CommandsResult(true, "Marca ativada com sucesso!!!", mark);
        }
    }
}
