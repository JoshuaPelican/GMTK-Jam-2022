using UnityEngine;
using UnityEngine.UI;

public class Player : Entity
{
    public Weapon EquippedWeapon;
    DiceRoller roller;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!roller)
                return;

            roller.StopCurrentDice();
        }
    }

    public override void Initialize()
    {
        health.Value = 100;
        Streak.Value = 1f;
    }

    protected override void StartTurn(GameState gameState)
    {
        if (gameState != GameState.Player)
            return;

        //Nothing right now
    }

    public void UseWeapon()
    {
        //If player has no targets, find first available
        if(!target) SetTarget(FindObjectOfType<EnemyBase>());

        roller = UseAttack(EquippedWeapon.NumberOfDice);
    }

    public override void Attack(int value)
    {
        base.Attack(value);

        // Plays Sword Swing Anim
        GetComponentInChildren<AttackEffects>().isAttacking = true;
    }

    protected override void Die()
    {
        Debug.Log("Player is Dead!");
    }

    protected override void EndTurn()
    {
        GameManager.Instance.ChangeGameState(GameState.Enemy);
    }
}
