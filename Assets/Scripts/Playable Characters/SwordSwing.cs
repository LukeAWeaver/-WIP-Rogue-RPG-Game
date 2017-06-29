using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwing : MonoBehaviour {
    Animator swing;
    public AudioClip swinging;
    private AudioSource source;

    // Use this for initialization
    void Start () {
        swing = GetComponent<Animator>();
        source = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Collider2D>().enabled = true;
            swing.SetInteger("state", 1);
            source.clip = swinging;
                source.Play();

        }

        else if (Input.GetMouseButtonUp(0))
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
