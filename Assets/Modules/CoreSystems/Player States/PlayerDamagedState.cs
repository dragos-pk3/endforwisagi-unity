using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerDamagedState : State
{

    public PlayerDamagedState(Player owner) : base(owner) { name = "DAMAGED"; }
    private SpriteManager sm;
    private PlayerValues values;
    public override void Enter()
    {
        owner.isDamaged = true;
        values = owner.GetComponent<PlayerValues>();
        EventManager.HideWeapon();
        sm = owner.GetComponentInChildren<SpriteManager>();
        sm.PlayDamageEffect();
        owner.StartCoroutine(Timer());
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
        yield return new WaitForSeconds(values.RecoveryDuration);
        if (owner.isDamaged)
        {
            owner.ChangeStates(new PlayerIFramesState(owner)); // TODO: Better way to handle this
        }
    }

}