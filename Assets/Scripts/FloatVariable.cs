using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Float", menuName = "Variables/Float")]
public class FloatVariable : ScriptableObject
{
    public UnityEvent<float> OnValueChanged;

    [SerializeField]float value;
    public float Value
    {
        get { return value; }
        set
        {
            if(value != this.value)
            {
                this.value = value;
                OnValueChanged?.Invoke(value);
            }
        }
    }
}
