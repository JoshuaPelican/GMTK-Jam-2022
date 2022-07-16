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

        diceInPlay[currentDiceIndex].StartDice(0.25f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentDiceIndex >= diceInPlay.Length)
                return;

            StopCurrentDice();
        }
    }

    public void SetNumberOfDice(int value)
    {
        numberOfDice = value;
    }

    public void StopCurrentDice()
    {
        int roll = diceInPlay[currentDiceIndex].StopDice();
        OnDiceRolled?.Invoke(currentDiceIndex + 1, roll);
        totalDiceValue += roll;

        currentDiceIndex++;

        if (currentDiceIndex >= diceInPlay.Length)
        {
            RollerFinished();
            return;
        }

        diceInPlay[currentDiceIndex]?.StartDice(0.25f);
    }

    void RollerFinished()
    {
        Debug.Log("Roller Total: " + totalDiceValue);
        OnRollerFinished?.Invoke(totalDiceValue);
    }
}
