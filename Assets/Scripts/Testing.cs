using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField]
    private Transform damagePopup;

    private void Start()
    {
        Transform DamagePopupTransform = Instantiate(damagePopup, transform);
        DamagePopup _damagePopup = DamagePopupTransform.GetComponent<DamagePopup>();
        _damagePopup.Setup(6);
    }
}
