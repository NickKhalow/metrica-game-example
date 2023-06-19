using UnityEngine;

namespace GuidedMan
{
    public class Timer
    {
        private float _start;

        public void Start()
        {
            _start = Time.timeSinceLevelLoad;
        }

        public float PassedTime()
        {
            return Time.timeSinceLevelLoad - _start;
        }
    }
}