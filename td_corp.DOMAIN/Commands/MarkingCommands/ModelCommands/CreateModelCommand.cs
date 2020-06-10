using System;
using td_corp.SHARED;
using Flunt.Validations;
using Flunt.Notifications;

namespace td_corp.DOMAIN.Commands.MarkingCommands.ModelCommands
{
    public class CreateModelCommand : Notifiable, ICommand
    {        
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid MarkingId { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()
            .HasMinLen(Name, 3, "CreateModelCommand.Name", "Marca deve ter no mínimo 3 caracteres")
            .HasMaxLen(Name, 100, "CreateModelCommand.Name", "Marca deve ter no mínimo 3 caracteres")
            .HasMinLen(Description, 3, "CreateModelCommand.Description", "Modelo deve ter no máximo 60 caracteres")
            .HasMaxLen(Description, 100, "CreateModelCommand.Description", "Modelo deve ter no máximo 60 caracteres"));
        }
    }
}
