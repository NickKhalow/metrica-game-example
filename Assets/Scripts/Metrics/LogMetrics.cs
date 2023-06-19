#nullable enable
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Metrics
{
    public class LogMetrics : AbstractMetrics
    {
        [SerializeField] private AbstractMetrics? _metrics;

        public override void Send(string eventName, IReadOnlyDictionary<string, string> options)
        {
            if (_metrics != null)
            {
                _metrics.Send(eventName, options);
            }

            Debug.Log(
                $"Event sent: {eventName}\n{string.Join('\n', options.Select(e => $"Key: {e.Key} Value: {e.Value}"))}");
        }
    }
}