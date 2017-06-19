using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controls : MonoBehaviour
{
    private float velocity = 1f;
    public GameObject autoAttack;
    public string flip;
    public char previousKey;
    //public GameObject coin;
   // public GameObject collisionObject;
    //public GameObject smallObject;


    // Use this for initialization
    void Start()
    {
        previousKey = 'd';
    }

    // Update is called once per frame
    void Update()
    {
        /* CONTROLLER SUPPORT
        vlimit = Input.GetAxis("Vertical");
        hlimit = Input.GetAxis("Horizontal");
        if(Input.GetAxis("Vertical") <.1f && Input.GetAxis("Vertical") > -.1f)
        {
            transform.Translate(0f, Input.GetAxis("Vertical"), 0f);

        }
        else if (Input.GetAxis("Vertical") > .1f )
        {
            vlimit = .1f;
            transform.Translate(0f, vlimit, 0f);
        }
        else if (Input.GetAxis("Vertical") < -.1f)
        {
            vlimit = -.1f;
            transform.Translate(0f, vlimit, 0f);

        }
        if (Input.GetAxis("Horizontal") < .1f && Input.GetAxis("Horizontal") > -.1f)
        {
            transform.Translate(Input.GetAxis("Horizontal"), 0f, 0f);

        }

        else if (Input.GetAxis("Horizontal") > .1f)
        {
            hlimit = -.1f;
            transform.Translate(hlimit, 0f, 0f);

        }
        else if (Input.GetAxis("Horizontal") < -.1f)
        {
            hlimit = .1f;
            transform.Translate(hlimit, 0f, 0f);

        }
    */

        if (Input.GetKey("d"))
        {
            if (previousKey == 'a')
            {
                Flip("right");
            }
            transform.Translate(velocity, 0f, 0f);
            previousKey = 'd';
        }
        if (Input.GetKey("a"))
        {
            if (previousKey == 'd')
            {
                Flip("left");
            }
            transform.Translate(-velocity, 0f, 0f);
            previousKey = 'a';
        }
        if (Input.GetKey("w"))
        {
            transform.Translate(0f, velocity, 0f);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(0f, -velocity, 0f);
        }
    }
    public void Flip(string methodFlip)
    {
        var pos = transform.position;
        flip = methodFlip;
        var theScale = transform.localScale;
        if (flip == "right")
        {
            if (theScale.x < -.1f)
                theScale.x = -theScale.x;
                 pos.x = pos.x - 2f;
                transform.SetPositionAndRotation((pos), transform.rotation);
        }
        if (flip == "left")
        {
            if (theScale.x > .1f)
                theScale.x = -theScale.x;
                pos.x = pos.x + 2f;
                transform.SetPositionAndRotation((pos), transform.rotation);
        }
        transform.localScale = theScale;
    }




}
