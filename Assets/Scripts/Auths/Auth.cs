using System;
using System.Collections.Generic;
using Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Auths
{
    public class Auth : MonoBehaviour
    {
        [SerializeField] private AbstractMetrics _metrics;
        [SerializeField] private Button _sendButton;
        [SerializeField] private TMP_InputField _nameField;

        private void Awake()
        {
            _metrics.EnsureNotNull("Metrics is not specified");
            _sendButton.EnsureNotNull("Send button is not installed");
            _nameField.EnsureNotNull("Name field is not found");
        }

        private void Start()
        {
            AppMetrica.Instance.ReportEvent("appStarted");
            _metrics.Send("appStarted");
            _sendButton.onClick.AddListener(() =>
                {
                    _metrics.Send(
                        "auth",
                        new Dictionary<string, string>
                        {
                            ["newName"] = _nameField.text
                        }
                    );
                }
            );
        }
    }
}