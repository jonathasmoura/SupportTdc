
using System;
using Flunt.Notifications;
using Flunt.Validations;
using td_corp.SHARED;

namespace td_corp.DOMAIN.Commands.MarkingCommands
{
    public class InactiveMarkingByIdCommand : Notifiable, ICommand
    {
        public InactiveMarkingByIdCommand() { }

        public InactiveMarkingByIdCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
        public void Validate(){}
    }
}
