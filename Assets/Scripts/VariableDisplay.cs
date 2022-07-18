using UnityEngine;
using TMPro;

public class VariableDisplay : MonoBehaviour
{
    [SerializeField] FloatVariable Variable;

    [SerializeField] string Prefix;
    [SerializeField] string Suffix;

    TextMeshProUGUI VariableTextMesh;

    private void Awake()
    {
        VariableTextMesh = GetComponent<TextMeshProUGUI>();
        Variable.OnValueChanged.AddListener(OnValueChanged);
        OnValueChanged(Variable.Value);
    }

    void OnValueChanged(float value)
    {
        VariableTextMesh.SetText(Prefix + value.ToString() + Suffix);
    }


}
