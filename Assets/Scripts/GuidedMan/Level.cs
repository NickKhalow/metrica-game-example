using System;
using System.Collections.Generic;
using System.Linq;
using Extensions;
using Unity.VisualScripting;
using UnityEngine;

namespace GuidedMan
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Finish finish;
        [SerializeField] private Player player;
        [SerializeField] private AbstractMetrics metrics;
        [SerializeField] private List<Star> stars = new();
        private readonly Timer _timer = new();

        private void Awake()
        {
            player.EnsureNotNull("Player not found");
            finish.EnsureNotNull("Finish not found");
            metrics.EnsureNotNull("Metrics not found");
            stars = stars.Concat(FindObjectsOfType<Star>()).Distinct().ToList();
        }

        private void Start()
        {
            _timer.Start();
            metrics.Send("level_started");
            finish.finished.AddListener(() =>
                {
                    metrics.Send(
                        "level_finished",
                        new Dictionary<string, string>
                        {
                            ["time"] = _timer.PassedTime().ToString(),
                            ["collected_stars"] = stars.Count(e => e.Collected).ToString(),
                            ["total_stars"] = stars.Count.ToString()
                        }
                    );
                    player.gameObject.SetActive(false);
                }
            );
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                metrics.Send("level_paused",
                    new Dictionary<string, string>
                    {
                        ["time"] = _timer.PassedTime().ToString()
                    }
                );
            }
        }
    }
}