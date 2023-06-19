using System;
using UnityEngine;

namespace GuidedMan
{
    [RequireComponent(typeof(Collider))]
    public class Star : MonoBehaviour
    {
        [SerializeField] private bool collected;
        [SerializeField] private Vector3 rotation;

        private void Update()
        {
            transform.Rotate(rotation);
        }

        public bool Collected => collected;

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            Collect();
        }


        public void OnTriggerEnter(Collider other)
        {
            Collect();
        }

        private void Collect()
        {
            collected = true;
            gameObject.SetActive(false);
        }
    }
}