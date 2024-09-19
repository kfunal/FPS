using FPS.FSM;
using FPS.Input;

namespace FPS.Character
{
    public class CharacterState : BaseState
    {
        protected CharacterManager Manager;
        protected InputManager InputManager;

        protected float Speed => InputManager.Run ? Manager.RunSpeed : Manager.WalkSpeed;
        protected bool Jump => InputManager.Jump && Manager.IsGrounded;
        protected bool Crouch => InputManager.Crouch && Manager.IsGrounded;

        public CharacterState(InputManager _inputManager, CharacterManager _manager, string _name) : base(_manager, _name)
        {
            InputManager = _inputManager;
            Manager = _manager;
        }

        public override void Update()
        {
            base.Update();

            Manager.RotateCharacter();
            Manager.ApplyGravity();
        }
    }
}
