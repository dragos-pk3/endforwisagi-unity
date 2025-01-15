using UnityEngine;

public abstract class State
{
    protected GameObject owner;
    public string name; // Debug only, delete later
    protected State(GameObject owner)
    {
        this.owner = owner;
    }
    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}