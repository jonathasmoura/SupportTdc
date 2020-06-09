using Flunt.Notifications;
using Flunt.Validations;
using td_corp.SHARED;

namespace td_corp.DOMAIN.Commands.MarkingCommands
{
    public class CreateMarkingCommand : Notifiable, ICommand
    {
        public CreateMarkingCommand() { }

        public CreateMarkingCommand(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()
            .HasMinLen(Name, 3, "CreateMarkingCommand.Name", "Marca deve ter no mínimo 3 caracteres")
            .HasMaxLen(Name, 100, "CreateMarkingCommand.Name", "Marca deve ter no mínimo 3 caracteres"));
        }
    }
}
