using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freehand : MonoBehaviour
{
    Animator swing;

    private bool AAOnCD;
    public int test;

    // Use this for initialization
    void Start()
    {
        swing = GetComponent<Animator>();        test = 0;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        AAOnCD = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GetComponentInParent<KnightStats>().energy > 0 && !AAOnCD)
        {
            StartCoroutine(AutoAttack());
        }
        else if (!(Input.GetKey("a") && Input.GetKey("d")) && (Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("w") || Input.GetKey("s")) && !(Input.GetKey("s") && Input.GetKey("w")))
        {
            swing.SetInteger("state", 2);
        }
        else
            swing.SetInteger("state", 0);
    }

    IEnumerator AutoAttack()
    {
        AAOnCD = true;
        GetComponentInParent<KnightStats>().energy--;
        GetComponent<Collider>().enabled = true;
        swing.SetInteger("state", 1);

        yield return new WaitForSeconds(.2f);
        GetComponent<Collider>().enabled = false;
        swing.SetInteger("state", 0);

        yield return new WaitForSeconds(.4f);
        AAOnCD = false;


    }
}
