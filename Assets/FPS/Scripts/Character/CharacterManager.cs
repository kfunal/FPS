using FPS.FSM;
using FPS.Input;
using UnityEngine;

namespace FPS.Character
{
    public class CharacterManager : StateMachine
    {
        #region States

        public CHIdle IdleState { get; private set; }
        public CHLand LandState { get; private set; }
        public CHJump JumpState { get; private set; }
        public CHCrouch CrouchState { get; set; }

        #endregion

        #region Inspector

        [Header("Script References")]
        [SerializeField] private InputManager inputManager;

        [field: Header("Movement Parameters")]
        [field: SerializeField] public float WalkSpeed { get; private set; }
        [field: SerializeField] public float RunSpeed { get; private set; }
        [field: SerializeField] public float CrouchWalkSpeed { get; private set; }

        [Header("Camera")]
        [SerializeField] private float cameraTopLimit;
        [SerializeField] private float cameraBottomLimit;
        [SerializeField] private float sensitivity;
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private Transform cameraRoot;

        [Header("Gravity")]
        [SerializeField] private float gravity = -9.81f;
        [SerializeField] private float groundCheckRadius = 0.4f;
        [SerializeField] private float jumpHeight = 2f;
        [SerializeField] private Transform groundCheckPoint;
        [SerializeField] private LayerMask groundCheckLayer;

        [Header("Animation")]
        [SerializeField] private string movementHorizontalAxis;
        [SerializeField] private string movementVerticalAxis;
        [SerializeField] private string jumpAnimatorParameter;
        [SerializeField] private string crouchAnimatorParameter;
        [SerializeField] private float movementAnimationSmoothTime;

        #endregion 

        #region Props

        public CharacterController CharacterController { get; private set; }
        public Animator Animator { get; private set; }

        public bool IsGrounded => Physics.CheckSphere(groundCheckPoint.position, groundCheckRadius, groundCheckLayer);
        public string JumpAnimationParameter => jumpAnimatorParameter;
        public string CrouchAnimationParameter => crouchAnimatorParameter;

        #endregion

        #region Variables

        private float xAxis;
        private float yAxis;
        private float xRotation;

        private float movementAnimationHorizontalAxis;
        private float movementAnimationVerticalAxis;

        private float movementAnimationHorizontalVelocity;
        private float movementAnimationVerticalVelocity;

        private Vector3 direction;
        private Vector3 gravityVelocity;

        #endregion

        private void Awake()
        {
            ComponentReferences();
            InitStates();
        }

        public void MoveCharacter(float _speed)
        {
            direction = transform.right * inputManager.Movement.x + transform.forward * inputManager.Movement.y;
            CharacterController.Move(direction * _speed * Time.deltaTime);
        }

        public void RotateCharacter()
        {
            xAxis = inputManager.Look.x * sensitivity * Time.deltaTime;
            yAxis = inputManager.Look.y * sensitivity * Time.deltaTime;
            cameraTransform.position = cameraRoot.position;
            xRotation -= yAxis;
            xRotation = Mathf.Clamp(xRotation, cameraBottomLimit, cameraTopLimit);
            cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.rotation *= Quaternion.Euler(0, xAxis, 0);
        }

        public void ApplyGravity()
        {
            gravityVelocity.y += gravity * Time.deltaTime;

            if (IsGrounded && gravityVelocity.y < 0)
                gravityVelocity.y = -2f;

            CharacterController.Move(gravityVelocity * Time.deltaTime);
        }

        public void MovementAnimation(float _speed)
        {
            movementAnimationHorizontalAxis = Mathf.SmoothDamp(movementAnimationHorizontalAxis, inputManager.Movement.x * _speed, ref movementAnimationHorizontalVelocity, movementAnimationSmoothTime);
            movementAnimationVerticalAxis = Mathf.SmoothDamp(movementAnimationVerticalAxis, inputManager.Movement.y * _speed, ref movementAnimationVerticalVelocity, movementAnimationSmoothTime);

            Animator.SetFloat(movementHorizontalAxis, movementAnimationHorizontalAxis);
            Animator.SetFloat(movementVerticalAxis, movementAnimationVerticalAxis);
        }

        public void JumpCharacter() => gravityVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        private void ComponentReferences()
        {
            CharacterController = GetComponent<CharacterController>();
            Animator = GetComponent<Animator>();
        }

        private void InitStates()
        {
            IdleState = new CHIdle(inputManager, this);
            LandState = new CHLand(inputManager, this);
            JumpState = new CHJump(inputManager, this);
            CrouchState = new CHCrouch(inputManager, this);
        }

        public override BaseState StartState()
        {
            return IdleState;
        }
    }
}
