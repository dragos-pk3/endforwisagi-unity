using UnityEngine;

public abstract class State
{
    protected GameObject owner;
    public string name = "Unspecified"; // Debug only, delete later
    protected State(GameObject owner)
    {
        this.owner = owner;
    }
    public abstract void Enter();
    public abstract void Execute();
    public virtual void FixedExecute() { }
    public abstract void Exit();
}