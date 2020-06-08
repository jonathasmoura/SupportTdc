using System;
using td_corp.SHARED.Interfaces;

namespace td_corp.DOMAIN.CommandsResults
{
    public class CommandsResult : ICommandResult
    {
        public CommandsResult(){}
        public CommandsResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
