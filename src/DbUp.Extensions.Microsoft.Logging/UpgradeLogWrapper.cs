using DbUp.Engine;
using DbUp.Engine.Output;
using Microsoft.Extensions.Logging;

namespace DbUp.Extensions.Logging
{
    internal sealed class UpgradeLogWrapper : IUpgradeLog
    {
        private readonly ILogger<UpgradeEngine> _logger;

        public UpgradeLogWrapper(ILogger<UpgradeEngine> logger)
        {
            _logger = logger;
        }

        public void WriteInformation(string format, params object[] args)
        {
            if (_logger.IsEnabled(LogLevel.Information))
                _logger.LogInformation(format, args);
        }

        public void WriteError(string format, params object[] args)
        {
            if (_logger.IsEnabled(LogLevel.Error))
                _logger.LogError(format, args);
        }

        public void WriteWarning(string format, params object[] args)
        {
            if (_logger.IsEnabled(LogLevel.Warning))
                _logger.LogWarning(format, args);
        }
    }
}
