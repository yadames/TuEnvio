using System;
using System.Collections.Generic;
using System.Text;

namespace TuEnvio.Utils
{
    public interface IFirebaseAnalyticsService
    {
        void LogEvent(string eventId);
        void LogEvent(string eventId, string paramName, string value);
        void LogEvent(string eventId, IDictionary<string, string> parameters);
        void SetUserId(string userId);
    }
}
