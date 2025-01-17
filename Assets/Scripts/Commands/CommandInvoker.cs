using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{

    private static CommandInvoker _invokerInstance;
    public static CommandInvoker InvokerInstance
    {
        get
        {
            if(_invokerInstance == null)
            {
                _invokerInstance = FindFirstObjectByType<CommandInvoker>();

                if (_invokerInstance == null ) {
                        GameObject commandInvoker = new GameObject("CommandInvoker");
                        _invokerInstance = commandInvoker.AddComponent<CommandInvoker>();
                }
            }
                return _invokerInstance;
        }
    }

    private Queue<ICommand> commandQueue = new Queue<ICommand>();

    public void AddCommand(ICommand command)
    {
        commandQueue.Enqueue(command);
    }

    private void Update()
    {
        // Execute all commands in the queue this frame
        while (commandQueue.Count > 0)
        {
            var cmd = commandQueue.Dequeue();
            cmd.Execute();
        }
    }
}
