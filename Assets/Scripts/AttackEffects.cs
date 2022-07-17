using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffects : MonoBehaviour
{
    [HideInInspector]
    public bool isAttacking = false;
    private int randomNum = 0;
    

    // Update is called once per frame
    void Update()
    {
        if (isAttacking)
        {
            StartCoroutine(SwingSword());
        }

        /*if (Input.GetKeyDown(KeyCode.R))
        {
            isAttacking = true;
        }*/
    }

    

    IEnumerator SwingSword()
    {
        randomNum = Random.Range(0, 3);

        if(randomNum == 0) 
        {
            GetComponent<Animator>().Play("SwordSwing");
        }
        if(randomNum == 1) 
        {
            GetComponent<Animator>().Play("SwordSwingVertical");
        }
        if(randomNum == 2) 
        {
            GetComponent<Animator>().Play("SwordThrust");
        }

        Debug.Log(randomNum);

        isAttacking = false;
        yield return new WaitForSeconds(2.0f);
        GetComponent<Animator>().Play("Idle");
    }
}
