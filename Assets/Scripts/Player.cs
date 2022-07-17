using UnityEngine;
using UnityEngine.UI;

public class Player : Entity
{
    [SerializeField] Weapon EquippedWeapon;
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

    protected override void Initialize()
    {
        health = 100;
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

    protected override void Die()
    {
        Debug.Log("Player is Dead!");
    }

    protected override void EndTurn()
    {
        GameManager.Instance.ChangeGameState(GameState.Enemy);
    }
}
