using System;
using SpaceXAPI.Infrastructure.Enums;

namespace SpaceXAPI.Interfaces
{
    public interface ILogEvents
{
        /// <summary>
        /// Log Event
        /// </summary>
        /// <param name="source">Source of error</param>
        /// <param name="ex">Exception</param>
        /// <param name="severity">EventLogSeverity</param>
        /// <returns>bool</returns>
        bool LogEvent(string source, Exception ex, EventLogSeverity severity, string message);

        /// <summary>
        /// Log Event
        /// </summary>
        /// <param name="source">Source</param>
        /// <param name="message">Message</param>
        /// <param name="severity">EventLogSeverity</param>
        /// <returns>bool</returns>
        bool LogEvent(string source, string message, EventLogSeverity severity);

        /// <summary>
        /// Log Event
        /// </summary>
        /// <param name="source">Source</param>
        /// <param name="ex">Exception</param>
        /// <returns>bool</returns>
        bool LogEvent(string source, Exception ex);

        /// <summary>
        /// Log Event
        /// </summary>
        /// <param name="source">Source</param>
        /// <param name="message">Message</param>
        /// <param name="ex">Exception</param>
        /// <returns>bool</returns>
        bool LogEvent(string source, string message, Exception ex);

        /// <summary>
        /// LogMessage
        /// </summary>
        /// <param name="message"></param>
        void LogMessage(string message);

        /// <summary>
        /// LogMessage
        /// </summary>
        /// <param name="source">Source</param>
        /// <param name="message">Message</param>
        /// <param name="severity">EventLogSeverity</param>
        void LogMessage(string source, string message, EventLogSeverity severity);

        /// <summary>
        /// LogException
        /// </summary>
        /// <param name="source">Source</param>
        /// <param name="message">Message</param>
        /// <param name="ex">LogException</param>
        void LogException(string source, string message, Exception ex);
    }
}
