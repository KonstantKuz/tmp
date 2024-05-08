using System.Collections.Generic;
using Fusion;
using Fusion.Addons.FSM;
using Fusion.Addons.KCC;
using Service.InputService;
using UnityEngine;

namespace Component.Character
{
    public class CharacterController : NetworkBehaviour, IStateMachineOwner
    {
        [field:SerializeField]
        public CharacterControllerParamsPreset ParamsPreset { get; private set; }

        [field:SerializeField]
        public KCC KinematicController { get; private set; }

        [field:SerializeField]
        public AnimationController AnimationController { get; private set; }

        private CharacterControllerParams _params;
        private CharacterStateMachine _movementMachine;
        private CharacterStateMachine _attackMachine;

        public DefaultInput? Input { get; set; }
        public NetworkButtons? PreviousButtons { get; set; }
        public CharacterControllerParams Params
        {
            get => _params;
            set => SetParams(value);
        }

        private void SetParams(CharacterControllerParams newParams)
        {
            _params = newParams;

            EnvironmentProcessor environmentProcessor = KinematicController.GetProcessor<EnvironmentProcessor>();
            environmentProcessor.KinematicSpeed = _params.Speed;
            environmentProcessor.JumpMultiplier = _params.JumpForce;
        }

        public override void Spawned()
        {
            Params = ParamsPreset.Value;
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
