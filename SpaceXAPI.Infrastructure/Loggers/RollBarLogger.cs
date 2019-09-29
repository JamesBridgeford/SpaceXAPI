using Microsoft.Extensions.Options;
using Rollbar;
using SpaceXAPI.Core.Models;
using SpaceXAPI.Infrastructure.Enums;
using SpaceXAPI.Interfaces;
using System;

namespace SpaceXAPI.Infrastructure
{
    public class RollBarLogger : ILogEvents
    {
        private readonly LoggerData _logSettings;
        private readonly AppSettings _appSettings;

        public RollBarLogger(IOptions<LoggerData> loggerOptions, IOptions<AppSettings> appSettings)
        {
            _logSettings = loggerOptions.Value;
            _appSettings = appSettings.Value;
            RollbarLocator.RollbarInstance.Configure(new RollbarConfig(_logSettings.RollBar.Key) { Environment = _appSettings.Environment });
        }
        public bool LogEvent(string source, Exception ex, EventLogSeverity severity, string message)
        {
            switch (severity)
            {
                case EventLogSeverity.Debug:
                    RollbarLocator.RollbarInstance.Debug(ex);
                    break;
                case EventLogSeverity.Error:
                    RollbarLocator.RollbarInstance.Error(ex);
                    break;
                case EventLogSeverity.Fatal:
                    RollbarLocator.RollbarInstance.Error(ex);
                    break;
                case EventLogSeverity.Information:
                    RollbarLocator.RollbarInstance.Info(ex);
                    break;
                case EventLogSeverity.None:
                    RollbarLocator.RollbarInstance.Info(ex);
                    break;
                case EventLogSeverity.Warning:
                    RollbarLocator.RollbarInstance.Warning(ex);
                    break;
            }

            return true;
        }

        public bool LogEvent(string source, string message, EventLogSeverity severity)
        {
            return LogEvent(source, new Exception(message), EventLogSeverity.Error, message);
        }
        public bool LogEvent(string source, Exception ex)
        {
            return LogEvent(source, ex, EventLogSeverity.Error, ex.Message);
        }

        public bool LogEvent(string source, string message, Exception ex)
        {
            return LogEvent(source, ex, EventLogSeverity.Error, message);
        }

        public void LogMessage(string message)
        {
            LogEvent(null, new Exception(message), EventLogSeverity.Error, message);
        }

        public void LogMessage(string source, string message, EventLogSeverity severity)
        {
            LogEvent(source, message, severity);
        }

        public void LogException(string source, string message, Exception ex)
        {
            LogEvent(source, message, ex);
        }


    }
}
