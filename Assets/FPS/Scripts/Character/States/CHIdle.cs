using FPS.Input;
using UnityEngine;

namespace FPS.Character
{
    public class CHIdle : CharacterState
    {
        public CHIdle(InputManager _inputManager, CharacterManager _manager) : base(_inputManager, _manager, nameof(CHIdle)) { }

        public override void Update()
        {
            base.Update();

            Manager.MovementAnimation(0f);

            if (Jump)
                Manager.ChangeState(Manager.JumpState);
            else if (Crouch)
                Manager.ChangeState(Manager.CrouchState);
            else if (InputManager.Movement.magnitude > 0.1f)
                Manager.ChangeState(Manager.LandState);
        }

    }
}
