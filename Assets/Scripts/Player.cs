using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] DiceRoller DiceRollerPrefab;

    [SerializeField] Weapon equippedWeapon;

    float streak;


    public void UseWeapon()
    {
        Instantiate(DiceRollerPrefab, transform.parent).SetNumberOfDice(equippedWeapon.NumberOfDice);
    }

    public void AddSreak(float value)
    {
        streak += value;
    }
}
