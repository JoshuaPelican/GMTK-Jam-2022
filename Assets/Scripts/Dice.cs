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

    [SerializeField] FloatVariable PlayerStreak;
    [SerializeField] FloatVariable StreakMultiplier;

    public void StartDice(float _speed)
    {
        active = true;
        speed = _speed * PlayerStreak.Value;

        Invoke(nameof(NextValue), 1 / speed);
    }

    public int StopDice()
    {
        active = false;

        ApplyStreak();

        //Debug.Log("Dice rolled: " + value);
        return value;
    }

    void NextValue()
    {
        if (!active)
            return;

        sequenceIndex = sequenceIndex >= 5 ? 0 : sequenceIndex + 1;

        value = diceSequence[sequenceIndex];
        valueTextMesh.SetText(value.ToString());

        Invoke(nameof(NextValue), 1 / speed);
    }

    void ApplyStreak()
    {
        float streakPercent = (value / 6f) + 0.5f;
        PlayerStreak.Value *= streakPercent * StreakMultiplier.Value;
        PlayerStreak.Value = Mathf.Clamp(PlayerStreak.Value, 1, float.MaxValue);
    }
}
