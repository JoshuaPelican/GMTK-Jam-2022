using UnityEngine;
using UnityEngine.UI;

public class Player : Entity
{
    [SerializeField] Weapon EquippedWeapon;

    public void UseWeapon()
    {
        //If player has no targets, find first available
        if(!target) SetTarget(FindObjectOfType<EnemyBase>());

        UseAttack(EquippedWeapon.NumberOfDice, RollerPoint);
    }

    protected override void Die()
    {
        Debug.Log("Player is Dead!");
    }
}
