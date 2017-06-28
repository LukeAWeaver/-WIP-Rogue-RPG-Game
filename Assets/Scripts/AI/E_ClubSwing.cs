﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_ClubSwing : MonoBehaviour
{
    Animator swing;
    //GameObject weapon;
    // Use this for initialization
    void Start()
    {

        swing = GetComponent<Animator>();
        swing.SetBool("inProx", false);
        //InvokeRepeating("CheckAction", 0f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Knight_Player")
        {
            swing.SetBool("inProx", true);
            collision.gameObject.GetComponent<KnightStats>().health--; //im a genius
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        swing.SetBool("inProx", false);

    }
}