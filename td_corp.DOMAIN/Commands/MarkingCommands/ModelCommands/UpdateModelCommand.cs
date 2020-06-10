using System;
using td_corp.SHARED;
using Flunt.Validations;
using Flunt.Notifications;

namespace td_corp.DOMAIN.Commands.MarkingCommands.ModelCommands
{
    public class UpdateModelCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()
            .HasMinLen(Name, 3, "UpdateModelCommand.Name", "Marca deve ter no mínimo 3 caracteres")
            .HasMaxLen(Name, 100, "UpdateModelCommand.Name", "Marca deve ter no mínimo 3 caracteres")
            .HasMinLen(Description, 3, "UpdateModelCommand.Description", "Modelo deve ter no máximo 60 caracteres")
            .HasMaxLen(Description, 100, "UpdateModelCommand.Description", "Modelo deve ter no máximo 60 caracteres"));
        }
    }
}
