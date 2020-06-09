using System;
using td_corp.SHARED;
using Flunt.Validations;
using Flunt.Notifications;

namespace td_corp.DOMAIN.Commands.MarkingCommands
{
    public class EditMarkingCommand : Notifiable, ICommand
    {
        public EditMarkingCommand() { }

        public EditMarkingCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()
            .HasMinLen(Name, 3, "EditMarkingCommand.Name", "Marca deve ter no mínimo 3 caracteres")
            .HasMaxLen(Name, 100, "EditMarkingCommand.Name", "Marca deve ter no mínimo 3 caracteres"));
        }
    }
}
