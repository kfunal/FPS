using UnityEngine;

namespace FPS.FSM
{
    public abstract class StateMachine : MonoBehaviour
    {
        public BaseState CurrentState { get; private set; }

        private void Start()
        {
            CurrentState = StartState();

            if (CurrentState != null)
                CurrentState.Enter();
        }

        private void Update()
        {
            if (CurrentState != null)
                CurrentState.Update();
        }

        public void ChangeState(BaseState _nextState)
        {
            CurrentState.Exit();
            _nextState.Enter();
            CurrentState = _nextState;
        }

        public abstract BaseState StartState();
    }
}
