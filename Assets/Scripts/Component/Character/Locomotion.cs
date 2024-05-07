using Service.InputService;
using UnityEngine;

namespace Component.Character
{
    public class Locomotion : CharacterState
    {
        private bool _hasJumped;
        private int _jumpCount;

        protected override void OnFixedUpdate()
        {
            if (Input == null)
            {
                return;
            }

            Vector3 inputDirection =
                KinematicController.Data.TransformRotation * new Vector3(Input.Value.Move.x, 0, Input.Value.Move.y);
            KinematicController.SetInputDirection(inputDirection);

            if (KinematicController.Data.IsGrounded)
            {
                _jumpCount = 0;
            }

            _hasJumped = PreviousButtons != null &&
                         Input.Value.Buttons.WasPressed(PreviousButtons.Value, InputActions.Jump) &&
                         _jumpCount - 1 < Params.MaxInAirJumpCount;

            if (_hasJumped)
            {
                KinematicController.Jump(Vector3.up);
                _jumpCount++;
            }
        }

        protected override void OnRender()
        {
            if (Input == null)
            {
                return;
            }

            AnimationController.VerticalMotion = Input.Value.Move.y;
            AnimationController.HorizontalMotion = Input.Value.Move.x;
            AnimationController.HasJumped = _hasJumped;
            AnimationController.IsGrounded = KinematicController.Data.IsGrounded;
            _hasJumped = false;
        }
    }
}
