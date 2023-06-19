using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMetrics : MonoBehaviour
{
    private readonly IReadOnlyDictionary<string, string> _emptyOptions = new Dictionary<string, string>();

    public abstract void Send(string eventName, IReadOnlyDictionary<string, string> options);

    public void Send(string eventName)
    {
        Send(eventName, _emptyOptions);
    }
}