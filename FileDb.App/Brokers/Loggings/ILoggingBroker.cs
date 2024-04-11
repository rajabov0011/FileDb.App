using System;

namespace FileDb.App.Brokers.Loggings
{
    internal interface ILoggingBroker
    {
        void LogInforamation(string message);
        void LogError(string userMessage);
        void LogError(Exception exception);
        void LogSuccessUser(string message);
    }
}
