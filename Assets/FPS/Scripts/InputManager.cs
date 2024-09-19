using UnityEngine;
using UnityEngine.InputSystem;

namespace FPS.Input
{
    public class InputManager : MonoBehaviour
    {
        [field: SerializeField] public Vector2 Movement { get; private set; }
        [field: SerializeField] public Vector2 Look { get; private set; }
        [field: SerializeField] public bool Jump { get; private set; }
        [field: SerializeField] public bool Run { get; private set; }
        [field: SerializeField] public bool Crouch { get; private set; }

        private void OnMovement(InputValue _value) => Movement = _value.Get<Vector2>();
        private void OnLook(InputValue _value) => Look = _value.Get<Vector2>();
        private void OnJump(InputValue _value) => Jump = _value.isPressed;
        private void OnRun(InputValue _value) => Run = _value.isPressed;
        private void OnCrouch(InputValue _value) => Crouch = _value.isPressed;
    }
}
