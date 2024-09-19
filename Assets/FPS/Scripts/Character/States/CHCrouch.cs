using FPS.Input;
using UnityEngine;

namespace FPS.Character
{
    public class CHCrouch : CharacterState
    {
        public CHCrouch(InputManager _inputManager, CharacterManager _manager) : base(_inputManager, _manager, nameof(CHCrouch)) { }

        public override void Enter()
        {
            base.Enter();

            Manager.Animator.SetBool(Manager.CrouchAnimationParameter, true);
        }

        public override void Update()
        {
            base.Update();

            Manager.MoveCharacter(Manager.CrouchWalkSpeed);
            Manager.MovementAnimation(Manager.CrouchWalkSpeed);

            if (InputManager.Crouch) return;

            Manager.ChangeState(InputManager.Movement.magnitude > 0.1f ? Manager.LandState : Manager.IdleState);
        }

        public override void Exit()
        {
            base.Exit();
            Manager.Animator.SetBool(Manager.CrouchAnimationParameter, false);
        }
    }
}
