using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    private void Start()
    {
        Debug.Log(RollDice());
        Debug.Log(RollDice(6));
        Debug.Log(RollDice(new int[] { 1, 2, 3, 4, 5, 6 }));
    }

    public static int RollDice(int sides = 6)
    {
        return Random.Range(1, sides + 1);
    }

    public static int RollDice(int[] sides)
    {
        return sides[Random.Range(0, sides.Length)];
    }
}