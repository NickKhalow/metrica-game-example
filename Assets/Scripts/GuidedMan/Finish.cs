using System;
using UnityEngine;
using UnityEngine.Events;

namespace GuidedMan
{
    [RequireComponent(typeof(Collider))]
    public class Finish : MonoBehaviour
    {
        public UnityEvent finished = new();

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            finished.Invoke();
        }

        public void OnTriggerEnter(Collider other)
        {
            finished.Invoke();
        }
    }
}