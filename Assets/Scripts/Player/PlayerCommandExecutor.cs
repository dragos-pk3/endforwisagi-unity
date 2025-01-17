using UnityEngine;

[RequireComponent(typeof(CommandInvoker))]
[RequireComponent(typeof(PlayerStateManager))]
public class PlayerCommandExecutor : MonoBehaviour
{
    private PlayerStateManager _playerStateManager;
    private PlayerSubject _playerSubject;
    private DemoObserver _observer;
    private void Awake()
    {
        _playerStateManager = GetComponent<PlayerStateManager>();
        _playerSubject = GetComponent<PlayerSubject>();
        _observer = FindFirstObjectByType<DemoObserver>();
        _playerSubject.Subscribe(_observer);
    }

    private void Update()
    {
        bool isIdleInput = (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0);

        if (isIdleInput)
        {
            if (!(_playerStateManager.CurrentState is PlayerIdleState))
            {
                ICommand idleCommand = new ChangeStateCommand(
                    _playerStateManager,
                    new PlayerIdleState(gameObject)
                );
                CommandInvoker.InvokerInstance.AddCommand(idleCommand);

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
                CommandInvoker.InvokerInstance.AddCommand(moveCommand);

                ICommand notifyCommand = new NotifyObserversCommand(_playerSubject);
                CommandInvoker.InvokerInstance.AddCommand(notifyCommand);
            }
        }
    }
}
