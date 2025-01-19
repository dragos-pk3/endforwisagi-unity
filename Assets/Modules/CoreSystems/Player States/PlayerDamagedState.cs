using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerDamagedState : State
{

    public PlayerDamagedState(Player owner) : base(owner) { name = "DAMAGED"; }
    private SpriteManager sm;
    public override void Enter()
    {
        owner.isDamaged = true;
        owner.StartCoroutine(Timer());
        EventManager.HideWeapon();
        sm = owner.GetComponentInChildren<SpriteManager>();
        sm.PlayDamageEffect();
    }

    public override void Execute()
    {
    }

    public override void Exit()
    {
        EventManager.ShowWeapon();
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(owner.StunDuration);
        if (owner.isDamaged)
        {
            owner.ChangeStates(new PlayerIFramesState(owner)); // TODO: Better way to handle this
        }
    }

}