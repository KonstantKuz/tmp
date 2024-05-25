using System.Collections.Generic;
using Component.Character.State;
using Fusion;
using Fusion.Addons.FSM;
using Fusion.Addons.KCC;
using Service.InputService;
using UnityEngine;

namespace Component.Character
{
    public class NetworkCharacter : NetworkBehaviour, IStateMachineOwner
    {
        [field:SerializeField]
        public CharacterControllerParamsPreset ParamsPreset { get; private set; }

        [field:SerializeField]
        public KCC KinematicController { get; private set; }

        [field:SerializeField]
        public AnimationController AnimationController { get; private set; }

        private CharacterStateMachine _movementMachine;
        private CharacterStateMachine _attackMachine;

        [Networked]
        public DefaultInput Input { get; set; }
        [Networked]
        public NetworkButtons PreviousButtons { get; set; }
        [Networked]
        public NetworkCharacterParams Params { get; set; }

        private void SetParams(NetworkCharacterParams newParams)
        {
            Params = newParams;

            EnvironmentProcessor environmentProcessor = KinematicController.GetProcessor<EnvironmentProcessor>();
            environmentProcessor.KinematicSpeed = Params.Speed;
            environmentProcessor.JumpMultiplier = Params.JumpForce;
        }

        public override void Spawned()
        {
            SetParams(ParamsPreset.Value);
        }

        void IStateMachineOwner.CollectStateMachines(List<IStateMachine> stateMachines)
        {
            _movementMachine = new CharacterStateMachine(this, nameof(_movementMachine), new Locomotion());
            _attackMachine = new CharacterStateMachine(this, nameof(_attackMachine), new Attack());

            stateMachines.Add(_movementMachine);
            stateMachines.Add(_attackMachine);
        }
    }
}
