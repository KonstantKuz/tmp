using Fusion;
using Service.InputService;
using CharacterController = Component.Character.CharacterController;

namespace Component.Player
{
    public class PlayerCharacterController : NetworkBehaviour
    {
        private CharacterController _characterController;

        [Networked]
        private NetworkButtons PreviousButtons { get; set; }

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        public override void FixedUpdateNetwork()
        {
            bool hasInput = GetInput(out DefaultInput input);

            if (!hasInput)
            {
                _characterController.Input = null;
                return;
            }

            _characterController.Input = input;
            _characterController.PreviousButtons = PreviousButtons;

            PreviousButtons = input.Buttons;
        }
    }
}
