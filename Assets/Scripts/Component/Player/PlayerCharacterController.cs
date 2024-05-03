using Component.Character;
using Fusion;
using Fusion.Addons.KCC;
using Service.InputService;
using UnityEngine;

namespace Component.Player
{
    public class PlayerCharacterController : NetworkBehaviour
    {
        [SerializeField]
        private float _jumpForce;

        [SerializeField]
        private float speed;

        private KCC _kinematicController;
        private AnimationController _animationController;

        private bool _hasInput;
        private DefaultInput _input;
        private bool _hasJumped;

        [Networked]
        private NetworkButtons PreviousButtons { get; set; }

        private void Awake()
        {
            _kinematicController = GetComponent<KCC>();
            _animationController = GetComponent<AnimationController>();
        }

        public override void FixedUpdateNetwork()
        {
            _hasInput = GetInput(out _input);

            if (!_hasInput)
            {
                return;
            }

            Vector3 move = new Vector3(_input.Move.x, 0, _input.Move.y) * Runner.DeltaTime * speed;
            _kinematicController.AddExternalVelocity(move);
            _hasJumped = _input.Buttons.WasPressed(PreviousButtons, InputActions.Jump);
            if (_hasJumped)
            {
                _kinematicController.Jump(Vector3.up * _jumpForce * Runner.DeltaTime);
            }

            PreviousButtons = _input.Buttons;
        }

        public override void Render()
        {
            if (!_hasInput)
            {
                return;
            }

            _animationController.VerticalMotion = _input.Move.y;
            _animationController.HorizontalMotion = _input.Move.x;
            _animationController.HasJumped = _hasJumped;
            _animationController.IsGrounded = _kinematicController.Data.IsGrounded;
            _hasJumped = false;
        }
    }
}
