using FPS.Input;

namespace FPS.Character
{
    public class CHLand : CharacterState
    {
        public CHLand(InputManager _inputManager, CharacterManager _manager) : base(_inputManager, _manager, nameof(CHLand)) { }

        public override void Update()
        {
            base.Update();

            Manager.MoveCharacter(Speed);
            Manager.MovementAnimation(Speed);

            if (Jump)
                Manager.ChangeState(Manager.JumpState);
            else if (Crouch)
                Manager.ChangeState(Manager.CrouchState);
            else if (InputManager.Movement.magnitude <= 0f)
                Manager.ChangeState(Manager.IdleState);
        }
    }
}
