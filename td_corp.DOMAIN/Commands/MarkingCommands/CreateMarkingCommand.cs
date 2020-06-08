using System;
using Flunt.Notifications;
using Flunt.Validations;
using td_corp.SHARED;

namespace td_corp.DOMAIN.Commands.MarkingCommands
{
    public class CreateMarkingCommand : Notifiable, ICommand
    {
        public CreateMarkingCommand(){}
        public CreateMarkingCommand(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires().HasMinLen(Name, 3, "RegistrarMarcaCommand.Name", "Nome deve conter no mínimo 3 caracteres")
            .HasMaxLen(Name, 140, "RegistrarMarcaCommand.Name", "Nome deve conter no máximo 140 caracteres"));
        }
    }
}
