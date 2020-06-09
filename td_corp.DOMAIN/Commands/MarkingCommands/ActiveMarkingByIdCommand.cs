using System;
using td_corp.SHARED;
using Flunt.Notifications;

namespace td_corp.DOMAIN.Commands.MarkingCommands
{
    public class ActiveMarkingByIdCommand : Notifiable, ICommand
    {
        public ActiveMarkingByIdCommand() { }

        public ActiveMarkingByIdCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
        public void Validate()
        {}
    }
}
