using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwing : MonoBehaviour {
    Animator swing;
    GameObject weapon;
	// Use this for initialization
	void Start () {
        swing = GetComponent<Animator>();
        //InvokeRepeating("CheckAction", 0f, 0.3f);
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetMouseButton(0))
        {
            GetComponent<Collider2D>().enabled = true;
            swing.SetInteger("state", 1);

        }
        else if (!Input.GetMouseButtonUp(0))
        {
            GetComponent<Collider2D>().enabled = false;
            new WaitForSeconds(2);
            swing.SetInteger("state", 0);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "goblin")
        {
            collision.gameObject.GetComponent<AI>().Thisgoblin.hp--; //im a genius
        }
    }
}
