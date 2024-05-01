using Fusion;
using Fusion.Addons.KCC;
using Service.InputService;
using UnityEngine;
using Zenject;

namespace Component.Player
{
    public class PlayerCharacterController : NetworkBehaviour
    {
        [SerializeField]
        private float speed;

        private IInputService _inputService;
        private KCC _controller;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Awake()
        {
            _controller = GetComponent<KCC>();
        }

        public override void Spawned()
        {
            base.Spawned();
            _inputService.ActionsMap.Enable();
            _inputService.ActionsMap.Player.Move.performed += _ => Debug.Log("Trying to move!");
        }

        public override void FixedUpdateNetwork()
        {
            if (HasStateAuthority == false)
            {
                return;
            }

            Vector2 moveInput = _inputService.ActionsMap.Player.Move.ReadValue<Vector2>();
            Vector3 move = new Vector3(moveInput.x, 0, moveInput.y) * Runner.DeltaTime * speed;

            _controller.AddExternalVelocity(move);

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }
        }
    }
}
