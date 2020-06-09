using System;
using td_corp.SHARED;
using Flunt.Notifications;

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
