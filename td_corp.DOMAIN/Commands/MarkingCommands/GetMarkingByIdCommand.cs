
using System;
using Flunt.Notifications;
using Flunt.Validations;
using td_corp.SHARED;

namespace td_corp.DOMAIN.Commands.MarkingCommands
{
    public class GetMarkingByIdCommand : Notifiable, ICommand
    {
        public GetMarkingByIdCommand() { }

        public GetMarkingByIdCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
        public void Validate(){}
    }
}
