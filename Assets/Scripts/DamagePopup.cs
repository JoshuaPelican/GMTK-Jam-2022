using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{

    public float DestroyTime = 2f;
    public Vector3 offset = new Vector3(0, 2, 0);
    public Vector3 randomizeIntensity = new Vector3(0.5f, 0.5f, 0.5f);

    private TextMeshProUGUI text;

    private void Awake()
    {
        text = transform.GetComponent<TextMeshProUGUI>();
    }
    public void Setup(int damageAmount)
    {
        text.SetText(damageAmount.ToString());
    }
    private void Start()
    {
        transform.localPosition += offset;
        transform.localPosition += new Vector3(Random.Range(-randomizeIntensity.x, randomizeIntensity.x), 
            Random.Range(-randomizeIntensity.y, randomizeIntensity.y),
            Random.Range(-randomizeIntensity.z, randomizeIntensity.z));

        Destroy(gameObject, DestroyTime);

    }
}
