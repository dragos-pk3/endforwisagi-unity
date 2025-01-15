using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    private StateMachine stateMachine;

    [SerializeField]
    public string CurrentState;
    private void Start()
    {

        stateMachine = new StateMachine();
        stateMachine.ChangeState(new PlayerIdleState(gameObject));
        GetCurrentState();

    }

    private void Update()
    {
        stateMachine.Update();
        if (CurrentState != stateMachine.CurrentState.name) GetCurrentState();
    }

    public void ChangeState(State state) { stateMachine.ChangeState(state); }
    public void GetCurrentState() { CurrentState = stateMachine.CurrentState.name; }

}