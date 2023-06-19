using System.Collections.Generic;
using System.Linq;

namespace Metrics
{
    public class YandexMetrics : AbstractMetrics
    {
        public override void Send(string eventName, IReadOnlyDictionary<string, string> options)
        {
            AppMetrica.Instance.ReportEvent(
                eventName,
                options
                    .Select(e => new KeyValuePair<string, object>(e.Key, e.Value))
                    .ToDictionary(e => e.Key, e => e.Value)
            );
        }
    }
}