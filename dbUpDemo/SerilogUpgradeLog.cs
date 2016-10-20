using DbUp.Engine.Output;
using Serilog;

namespace dbUpDemo
{
    internal class SerilogUpgradeLog : IUpgradeLog
    {
        private readonly ILogger _logger;
        public SerilogUpgradeLog(ILogger logger)
        {
            _logger = logger;
        }

        public void WriteInformation(string format, params object[] args)
        {
            Log.Information(format, args);
        }

        public void WriteError(string format, params object[] args)
        {
            Log.Error(format, args);
        }

        public void WriteWarning(string format, params object[] args)
        {
            Log.Warning(format, args);
        }
        private ILogger Log { get { return _logger; } }
    }
}