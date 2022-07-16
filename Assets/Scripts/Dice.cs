using System.Collections;
using UnityEngine;
using TMPro;

public class Dice : MonoBehaviour
{
    readonly int[] diceSequence = {1, 5, 3, 4, 6, 2};

    [SerializeField] TextMeshProUGUI valueTextMesh;

    bool active;
    int sequenceIndex = 0;
    int value = 1;
    float speed;

    public void StartDice(float _speed)
    {
        active = true;
        speed = _speed;

        Invoke(nameof(NextValue), speed);
    }

    public int StopDice()
    {
        active = false;

        Debug.Log("Dice rolled: " + value);
        return value;
    }

    void NextValue()
    {
        if (!active)
            return;

        sequenceIndex = sequenceIndex >= 5 ? 0 : sequenceIndex + 1;

        value = diceSequence[sequenceIndex];
        valueTextMesh.SetText(value.ToString());

        Invoke(nameof(NextValue), speed);
    }
}
