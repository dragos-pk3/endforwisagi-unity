using UnityEngine;

public class ChangeStateCommand : ICommand
{
    private PlayerStateManager _playerStateManager;
    private State _newState;

    public ChangeStateCommand(PlayerStateManager stateManager, State newState)
    {
        _playerStateManager = stateManager;
        _newState = newState;
    }

    public void Execute()
    {
        _playerStateManager.ChangeState(_newState);
    }
}