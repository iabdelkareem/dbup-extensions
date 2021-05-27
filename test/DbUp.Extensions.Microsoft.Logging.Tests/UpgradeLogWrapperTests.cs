using System;
using System.Collections.Generic;
using DbUp.Engine;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using Xunit;

namespace DbUp.Extensions.Logging.Tests
{
    public class UpgradeLogWrapperTests
    {
        [Fact]
        public void WriteInformation_WhenInformationLogLevelIsNotEnabled_ShouldNotLog()
        {
            var mockLogger = A.Fake<ILogger<UpgradeEngine>>();
            var sut = new UpgradeLogWrapper(mockLogger);
            A.CallTo(() => mockLogger.IsEnabled(LogLevel.Information)).Returns(false);

            sut.WriteInformation("test log message", 5);

            A.CallTo(mockLogger).Where(o=> o.Method.Name == nameof(ILogger.Log)).MustNotHaveHappened();
        }

        [Fact]
        public void WriteInformation_WhenInformationLogLevelIsEnabled_ShouldLog()
        {
            var mockLogger = A.Fake<ILogger<UpgradeEngine>>();
            var sut = new UpgradeLogWrapper(mockLogger);
            A.CallTo(() => mockLogger.IsEnabled(LogLevel.Information)).Returns(true);

            sut.WriteInformation("test log message", 5);
            
            A.CallTo(mockLogger).Where(o=> o.Method.Name == nameof(ILogger.Log)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void WriteError_WhenErrorLogLevelIsNotEnabled_ShouldNotLog()
        {
            var mockLogger = A.Fake<ILogger<UpgradeEngine>>();
            var sut = new UpgradeLogWrapper(mockLogger);
            A.CallTo(() => mockLogger.IsEnabled(LogLevel.Error)).Returns(false);

            sut.WriteError("test log message", 5);

            A.CallTo(mockLogger).Where(o=> o.Method.Name == nameof(ILogger.Log)).MustNotHaveHappened();
        }

        [Fact]
        public void WriteError_WhenErrorLogLevelIsEnabled_ShouldLog()
        {
            var mockLogger = A.Fake<ILogger<UpgradeEngine>>();
            var sut = new UpgradeLogWrapper(mockLogger);
            A.CallTo(() => mockLogger.IsEnabled(LogLevel.Error)).Returns(true);

            sut.WriteError("test log message", 5);
            
            A.CallTo(mockLogger).Where(o=> o.Method.Name == nameof(ILogger.Log)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void WriteWarning_WhenWarningLogLevelIsNotEnabled_ShouldNotLog()
        {
            var mockLogger = A.Fake<ILogger<UpgradeEngine>>();
            var sut = new UpgradeLogWrapper(mockLogger);
            A.CallTo(() => mockLogger.IsEnabled(LogLevel.Warning)).Returns(false);

            sut.WriteWarning("test log message", 5);

            A.CallTo(mockLogger).Where(o=> o.Method.Name == nameof(ILogger.Log)).MustNotHaveHappened();
        }

        [Fact]
        public void WriteWarning_WhenWarningLogLevelIsEnabled_ShouldLog()
        {
            var mockLogger = A.Fake<ILogger<UpgradeEngine>>();
            var sut = new UpgradeLogWrapper(mockLogger);
            A.CallTo(() => mockLogger.IsEnabled(LogLevel.Warning)).Returns(true);

            sut.WriteWarning("test log message", 5);
            
            A.CallTo(mockLogger).Where(o=> o.Method.Name == nameof(ILogger.Log)).MustHaveHappenedOnceExactly();
        }
    }
}
