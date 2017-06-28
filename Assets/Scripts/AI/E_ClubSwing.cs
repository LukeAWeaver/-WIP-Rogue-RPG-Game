using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_ClubSwing : MonoBehaviour
{
    Animator swing;
    // Use this for initialization
    void Start()
    {
        swing = GetComponent<Animator>();
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
            if (collision.gameObject.GetComponent<KnightStats>().isRecovering)
            {

            }
            else
            {
                collision.gameObject.GetComponent<KnightStats>().health--; //im a genius
                collision.gameObject.GetComponent<KnightStats>().isRecovering = true; //im a genius
            }

            collision.gameObject.GetComponent<KnightStats>().tempHP = collision.gameObject.GetComponent<KnightStats>().health;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        swing.SetBool("inProx", false);

    }
}
