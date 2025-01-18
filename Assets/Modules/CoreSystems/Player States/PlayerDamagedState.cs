using UnityEngine;

public class PlayerDamagedState : State
{

    public PlayerDamagedState(GameObject owner) : base(owner) { name = "DAMAGED"; }
    
    private PlayerStatsHandler playerStatsHandler;
    public override void Enter()
    {
        playerStatsHandler = owner.GetComponent<PlayerStatsHandler>();
        playerStatsHandler.CurrentHealth -= 10;
        owner.GetComponent<PlayerStateManager>().ChangeState(new PlayerIdleState(owner));

    }

    public override void Execute()
    {

    }

    public override void Exit()
    {

    }

}