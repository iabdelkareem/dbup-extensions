using System;
using DbUp.Builder;
using DbUp.Engine;
using Microsoft.Extensions.Logging;

namespace DbUp.Extensions.Logging
{
    public static class UpgradeEngineBuilderExtensions
    {
        public static UpgradeEngineBuilder AddLoggerFromServiceProvider(this UpgradeEngineBuilder upgradeEngineBuilder, IServiceProvider serviceProvider)
        {
            var logger = (ILogger<UpgradeEngine>) serviceProvider.GetService(typeof(ILogger<UpgradeEngine>));
            return upgradeEngineBuilder.AddLogger(logger);
        }

        public static UpgradeEngineBuilder AddLogger(this UpgradeEngineBuilder upgradeEngineBuilder, ILogger<UpgradeEngine> logger)
        {
            upgradeEngineBuilder.LogTo(new UpgradeLogWrapper(logger));
            return upgradeEngineBuilder;
        }
    }
}