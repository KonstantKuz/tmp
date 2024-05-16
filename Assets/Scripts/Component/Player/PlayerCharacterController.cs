using Component.Character;
using Fusion;
using Service.InputService;

namespace Component.Player
{
    public class PlayerCharacterController : NetworkBehaviour
    {
        private NetworkCharacter _character;

        [Networked]
        private NetworkButtons PreviousButtons { get; set; }

        private void Awake()
        {
            _character = GetComponent<NetworkCharacter>();
        }

        public override void FixedUpdateNetwork()
        {
            GetInput(out DefaultInput input);

            _character.Input = input;
            _character.PreviousButtons = PreviousButtons;

            PreviousButtons = input.Buttons;
        }
    }
}
