using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
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
