public class StateMachine
{
    private State currentState;
    public State CurrentState => currentState;
    public void ChangeState(State state)
    {
        currentState?.Exit();
        currentState = state;
        currentState.Enter();
    }
    public void Update()
    {
        currentState?.Execute();
    }

    public void FixedUpdate()
    {
        currentState?.FixedExecute();
    }
}
