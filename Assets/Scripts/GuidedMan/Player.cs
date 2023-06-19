using UnityEngine;

namespace GuidedMan
{
    [RequireComponent(typeof(CharacterController))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float speed = 30;
        private CharacterController _controller;

        private void Start()
        {
            _controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            _controller.Move(new Vector3(
                    Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")
                ) * (speed * Time.deltaTime)
            );
        }
    }
}