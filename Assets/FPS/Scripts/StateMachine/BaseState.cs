namespace FPS.FSM
{
    public class BaseState
    {
        public string Name;
        protected StateMachine Machine;

        public BaseState(StateMachine _manager, string _name)
        {
            Machine = _manager;
            Name = _name;
        }

        public virtual void Enter() { }
        public virtual void Update() { }
        public virtual void Exit() { }
    }
}
