using UnityEngine;
using UnityEngine.UI;

public class VariableSliderDisplay : MonoBehaviour
{
    [SerializeField] FloatVariable Variable;
    Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        Variable.OnValueChanged.AddListener(OnValueChanged);
    }

    void OnValueChanged(float value)
    {
        slider.value = value;
    }
}
