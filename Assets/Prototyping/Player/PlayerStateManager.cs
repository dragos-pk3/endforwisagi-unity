using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    private StateMachine stateMachine;

    [SerializeField]
    public string CurrentStateString;

    public State CurrentState;
    private void Start()
    {
        stateMachine = new StateMachine();
        stateMachine.ChangeState(new PlayerIdleState(gameObject));
        GetCurrentState();
    }

    private void Update()
    {
        stateMachine.Update();
        if (CurrentState != stateMachine.CurrentState) GetCurrentState();
    }

    private void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }

    public void ChangeState(State state) { stateMachine.ChangeState(state); }
<<<<<<< HEAD:Assets/Prototyping/Player/PlayerStateManager.cs
    public void GetCurrentState() { CurrentState = stateMachine.CurrentState; CurrentStateString = stateMachine.CurrentState.name;; }
=======
    public void GetCurrentState() { CurrentState = stateMachine.CurrentState; CurrentStateString = stateMachine.CurrentState.name; }
>>>>>>> main:Assets/Scripts/Player/PlayerStateManager.cs

}