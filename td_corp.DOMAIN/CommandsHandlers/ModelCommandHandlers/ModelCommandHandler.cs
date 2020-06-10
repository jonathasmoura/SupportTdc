using td_corp.SHARED;
using Flunt.Notifications;
using td_corp.DOMAIN.Entities;
using td_corp.SHARED.Interfaces;
using td_corp.DOMAIN.Repositories;
using td_corp.DOMAIN.CommandsResults;
using td_corp.DOMAIN.Commands.MarkingCommands.ModelCommands;

namespace td_corp.DOMAIN.ModelCommandHandlers
{
    public class ModelCommandHandler : Notifiable,
    ICommandHandler<CreateModelCommand>,
    ICommandHandler<UpdateModelCommand>,
    ICommandHandler<InactiveModelByIdCommand>,
    ICommandHandler<ActiveModelByIdCommand>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMarkingRepository _markingRepository;

        public ModelCommandHandler(IModelRepository modelRepository, IMarkingRepository markingRepository)
        {
            _modelRepository = modelRepository;
            _markingRepository = markingRepository;
        }
        public ICommandResult Handle(CreateModelCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandsResult(false, "Ops, não foi possível cadastrar o modelo.", command.Notifications);

            // if (_modelRepository.ExistsModel(command.Name, command.Description))
            //     return new CommandsResult(false, "Já existe dados do modelo informado em nossa base de dados", command);

            var mId = _markingRepository.GetById(command.MarkingId);
            
            var mod = new Model(command.Name,
            command.Description,
            mId.Id);

            AddNotifications(mod.Notifications);
            if (command.Invalid)
                return new CommandsResult(false, "Ops, não foi possível cadastrar o modelo.", command.Notifications);

            _modelRepository.CreateModel(mod);

            return new CommandsResult(true, "Modelo cadastrado com sucesso!!!", command);
        }

        public ICommandResult Handle(UpdateModelCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandsResult(false, "Ops, não foi possível atualizar o modelo.", command.Notifications);

            var mod = _modelRepository.GetById(command.Id);
            mod.UpdateDescription(command.Description);

            _modelRepository.UpdateModel(mod);

            return new CommandsResult(true, "Modelo atualizado com sucesso!!!", command);
        }

        public ICommandResult Handle(InactiveModelByIdCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandsResult(false, "Ops, não foi possível desativar o registro.", command.Notifications);

            var mod = _modelRepository.GetById(command.Id);
            mod.Inactivate();

            _modelRepository.UpdateModel(mod);

            return new CommandsResult(true, "Modelo desativado com sucesso!!!", command);
        }

        public ICommandResult Handle(ActiveModelByIdCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandsResult(false, "Ops, não foi possível ativar seu registro.", command.Notifications);

            var mod = _modelRepository.GetById(command.Id);
            mod.Activate();

            _modelRepository.UpdateModel(mod);

            return new CommandsResult(true, "Modelo ativado com sucesso!!!", command);
        }
    }
}