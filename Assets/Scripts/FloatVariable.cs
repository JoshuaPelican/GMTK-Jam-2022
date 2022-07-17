using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Float", menuName = "Variables/Float")]
public class FloatVariable : ScriptableObject
{
    public UnityEvent<float> OnValueChanged = new UnityEvent<float>();

    [SerializeField]float value;
    [SerializeField]Vector2 Clamp = new Vector2(0, 1);
    public float Value
    {
        get { return value; }
        set
        {
            if(value != this.value)
            {
                this.value = value;
                this.value = Mathf.Clamp(this.value, Clamp.x, Clamp.y);

                OnValueChanged?.Invoke(value);
            }
        }
    }
}
