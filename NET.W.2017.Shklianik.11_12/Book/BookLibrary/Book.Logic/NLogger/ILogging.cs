using System;
using NLog;

namespace Book.Logic
{
    public interface ILogging
    {
        void Debug(string message);

        void Debug(string message, Exception exception);

        void Info(string message);

        void Info(string nessage, Exception exception);

        void Warning(string message);

        void Warning(string message, Exception exception);

        void Error(string message);

        void Error(string message, Exception exception);

        void FatalError(string message);

        void FatalError(string message, Exception exception);
    }

    public class Logging : ILogging
    {
        private Logger logger;

        public Logging(string className)
        {
            if (string.IsNullOrWhiteSpace(className))
            {
                throw new ArgumentNullException("className is null");
            }

            logger = LogManager.GetLogger(className);
        }

        public void Debug(string message) => logger.Debug(message);

        public void Debug(string message, Exception exception) => logger.Debug(exception, message);

        public void Info(string message) => logger.Debug(message);

        public void Info(string message, Exception exception) => logger.Debug(exception, message);

        public void Warning(string message) => logger.Debug(message);

        public void Warning(string message, Exception exception) => logger.Debug(exception, message);

        public void Error(string message) => logger.Debug(message);

        public void Error(string message, Exception exception) => logger.Debug(exception, message);

        public void FatalError(string message) => logger.Debug(message);

        public void FatalError(string message, Exception exception) => logger.Debug(exception, message);
    }    
}
