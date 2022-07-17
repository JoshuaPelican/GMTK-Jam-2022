using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DiceRoller : MonoBehaviour
{
    [SerializeField] GameObject DicePrefab;

    int totalDiceValue = 0;

    int numberOfDice;
    Dice[] diceInPlay;
    int currentDiceIndex;

    FloatVariable streak;

    [HideInInspector]
    public UnityEvent<int, int> OnDiceRolled;
    [HideInInspector]
    public UnityEvent<int> OnRollerFinished;

    private void Start()
    {
        diceInPlay = new Dice[numberOfDice];

        for (int i = 0; i < numberOfDice; i++)
        {
            Dice newDice = Instantiate(DicePrefab, transform).GetComponent<Dice>();
            diceInPlay[i] = newDice;
        }

        diceInPlay[currentDiceIndex].StartDice(1f, streak);
    }

    public void Initialize(int numDice, FloatVariable streak)
    {
        numberOfDice = numDice;
        this.streak = streak;
    }

    public int CurrentDiceValue
    {
        get
        {
            return diceInPlay[currentDiceIndex].Value;
        }
    }

    public void StopCurrentDice()
    {
        //Dice roll
        int roll = diceInPlay[currentDiceIndex].StopDice();
        totalDiceValue += roll;

        OnDiceRolled?.Invoke(currentDiceIndex + 1, roll);

        currentDiceIndex++;

        if (currentDiceIndex >= diceInPlay.Length)
        {
            RollerFinished();
            return;
        }

        diceInPlay[currentDiceIndex].StartDice(1f, streak);
    }

    void RollerFinished()
    {
        Debug.Log("Roller Total: " + totalDiceValue);
        OnRollerFinished?.Invoke(totalDiceValue);
        Destroy(gameObject);
    }
}
