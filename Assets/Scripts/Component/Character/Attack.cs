using Service.InputService;
using StaticData;

namespace Component.Character
{
    public class Attack : CharacterState
    {
        private bool _hasAttacked;

        private void ResetAttackedState()
        {
            _hasAttacked = false;
        }

        protected override void OnEnterState()
        {
            AnimationController.EventsHandler[AnimationEvents.AttackFinished].AddListener(ResetAttackedState);
        }

        protected override void OnExitState()
        {
            AnimationController.EventsHandler[AnimationEvents.AttackFinished].RemoveListener(ResetAttackedState);
        }

        protected override void OnFixedUpdate()
        {
            if (Input == null)
            {
                return;
            }

            if (_hasAttacked)
            {
                return;
            }

            _hasAttacked = PreviousButtons != null &&
                           Input.Value.Buttons.WasPressed(PreviousButtons.Value, InputActions.Fire);
        }

        protected override void OnRender()
        {
            if (Input == null)
            {
                return;
            }

            AnimationController.HasAttacked = _hasAttacked;
        }
    }
}
