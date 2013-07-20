using Rock.Framework.Logging;

namespace Fullback.WebHost.Lib
{
    public class Logger : LoggerBase
    {
        private static ILogger _logWriter;

        public static ILogger LogWriter
        {
            get
            {
                if (_logWriter == null)
                {
                    _logWriter = LoggerFactory.GetInstance<Logger>();
                }
                return _logWriter;
            }
        }

        public static void SetLogger(ILogger logger)
        {
            _logWriter = logger;
        }

        private void AddAdditionalInfo(ILogEntry logEntry)
        {
        }


        protected override void OnPreLogSync(ILogEntry entry)
        {
            AddAdditionalInfo(entry);
            base.OnPreLogSync(entry);
        }
    }
}