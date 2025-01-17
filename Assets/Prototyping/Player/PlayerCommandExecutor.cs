using UnityEngine;

[RequireComponent(typeof(CommandInvoker))]
[RequireComponent(typeof(PlayerStateManager))]
public class PlayerCommandExecutor : MonoBehaviour
{
    private CommandInvoker _invoker;
    private PlayerStateManager _playerStateManager;
    private PlayerSubject _playerSubject;

    private void Awake()
    {
        _invoker = GetComponent<CommandInvoker>();
        _playerStateManager = GetComponent<PlayerStateManager>();
        _playerSubject = GetComponent<PlayerSubject>();
    }

    private void Update()
    {
        bool isIdleInput = (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0);

        if (isIdleInput)
        {
            if (!(_playerStateManager.CurrentState is PlayerIdleState))
            {
                ICommand moveCommand = new ChangeStateCommand(
                    _playerStateManager,
                    new PlayerIdleState(gameObject)
                );
                _invoker.AddCommand(moveCommand);

                ICommand notifyCommand = new NotifyObserversCommand(_playerSubject);
                _invoker.AddCommand(notifyCommand);
            }
        }
        else
        {
            if (!(_playerStateManager.CurrentState is PlayerMoveState))
            {
                ICommand moveCommand = new ChangeStateCommand(
                    _playerStateManager,
                    new PlayerMoveState(gameObject)
                );
                _invoker.AddCommand(moveCommand);

                ICommand notifyCommand = new NotifyObserversCommand(_playerSubject);
                _invoker.AddCommand(notifyCommand);
            }
        }
    }
}
