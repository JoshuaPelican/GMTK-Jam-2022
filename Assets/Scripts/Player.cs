using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] DiceRoller DiceRollerPrefab;
    [SerializeField] Weapon equippedWeapon;

    [SerializeField] Image image;

    [SerializeField] FloatVariable Streak;

    public void UseWeapon()
    {
        DiceRoller newRoller = Instantiate(DiceRollerPrefab, GameObject.FindWithTag("Canvas").transform).GetComponent<DiceRoller>();
        newRoller.SetNumberOfDice(equippedWeapon.NumberOfDice);
        newRoller.OnRollerFinished.AddListener(Attack);
    }

    void Attack(int value)
    {
        Debug.Log("Player Attacks For: " + value);
    }
}
