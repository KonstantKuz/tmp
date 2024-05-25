using Fusion;
using Fusion.Addons.KCC;
using Service.InputService;
using UnityEngine;

namespace Component.Character.State
{
    public class CharacterState : Fusion.Addons.FSM.State
    {
        protected CharacterStateMachine CharacterMachine => (CharacterStateMachine) Machine;
        protected KCC KinematicController => CharacterMachine.Owner.KinematicController;
        protected Transform Transform => CharacterMachine.Owner.transform;
        protected AnimationController AnimationController => CharacterMachine.Owner.AnimationController;
        protected DefaultInput Input => CharacterMachine.Owner.Input;
        public NetworkButtons PreviousButtons => CharacterMachine.Owner.PreviousButtons;
        public NetworkCharacterParams Params => CharacterMachine.Owner.Params;
    }
}
