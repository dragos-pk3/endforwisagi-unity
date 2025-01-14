using UnityEngine;

public interface IState
{
    void Enter();
    void Update();
    void Render();
    void Exit();
}
