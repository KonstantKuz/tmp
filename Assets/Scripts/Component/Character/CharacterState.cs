using Fusion;
using Fusion.Addons.FSM;
using Fusion.Addons.KCC;
using Service.InputService;

namespace Component.Character
{
    public class CharacterState : State
    {
        protected CharacterStateMachine CharacterMachine => (CharacterStateMachine) Machine;
        protected KCC KinematicController => CharacterMachine.Controller.KinematicController;
        protected AnimationController AnimationController => CharacterMachine.Controller.AnimationController;
        protected DefaultInput? Input => CharacterMachine.Controller.Input;
        public NetworkButtons? PreviousButtons => CharacterMachine.Controller.PreviousButtons;
        public CharacterControllerParams Params => CharacterMachine.Controller.Params;
    }
}
