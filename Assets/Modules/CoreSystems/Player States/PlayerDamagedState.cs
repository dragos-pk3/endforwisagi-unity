using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerDamagedState : State
{

    public PlayerDamagedState(Player owner) : base(owner) { name = "DAMAGED"; }
    private bool isDamaged = false;
    public override void Enter()
    {
        isDamaged = true;
        owner.StartCoroutine(Timer());
        EventManager.HideWeapon();
    }

    public override void Execute()
    {
    }

    public override void Exit()
    {
        isDamaged = false;
        EventManager.ShowWeapon();
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(owner.StunDuration);
        if (isDamaged)
        {
            owner.ChangeStates(new PlayerIdleState(owner)); // TODO: Better way to handle this
        }
    }

}