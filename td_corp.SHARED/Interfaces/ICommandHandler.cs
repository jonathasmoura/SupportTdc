using System;
using td_corp.SHARED.Interfaces;

namespace td_corp.SHARED
{
    public interface ICommandHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
