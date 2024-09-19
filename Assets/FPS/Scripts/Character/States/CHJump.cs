using FPS.FSM;
using FPS.Input;
using UnityEngine;

namespace FPS.Character
{
    public class CHJump : CharacterState
    {
        public CHJump(InputManager _inputManager, CharacterManager _manager) : base(_inputManager, _manager, nameof(CHJump)) { }
        private BaseState nextState;

        public override void Enter()
        {
            base.Enter();
            Manager.JumpCharacter();
            Manager.Animator.SetTrigger(Manager.JumpAnimationParameter);
        }

        public override void Update()
        {
            base.Update();

            Manager.MoveCharacter(Speed);
            if (!Manager.IsGrounded) return;
            Manager.ChangeState(InputManager.Movement.magnitude > 0.1f ? Manager.LandState : Manager.IdleState);
        }

        public override void Exit()
        {
            Manager.Animator.ResetTrigger(Manager.JumpAnimationParameter);
        }
    }
}
