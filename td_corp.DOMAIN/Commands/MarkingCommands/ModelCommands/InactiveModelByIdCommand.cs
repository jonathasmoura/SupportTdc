using System;
using td_corp.SHARED;
using Flunt.Notifications;

namespace td_corp.DOMAIN.Commands.MarkingCommands.ModelCommands
{
    public class InactiveModelByIdCommand : Notifiable, ICommand
    {
        public InactiveModelByIdCommand() { }

        public InactiveModelByIdCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
        public void Validate(){}
    }
}
