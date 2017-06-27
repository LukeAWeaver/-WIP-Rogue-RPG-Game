using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controls : MonoBehaviour
{
    private float velocity = .07f;
    public GameObject autoAttack;
    public string flip;
    public char previousKey;
    Animator walk;
    //public GameObject coin;
    // public GameObject collisionObject;
    //public GameObject smallObject;


    // Use this for initialization
    void Start()
    {
        walk = GetComponent<Animator>();
        previousKey = 'd';
    }

    // Update is called once per frame
    void Update()
    {
        walk.SetBool("walking", false);
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
            walk.SetBool("walking", true);
            walk.Play("walk");
            if (previousKey == 'a')
            {
                Flip("right");
            }
            transform.Translate(velocity, 0f, 0f);
            previousKey = 'd';
        }
        if (Input.GetKey("a"))
        {
            walk.SetBool("walking", true);
            walk.Play("walk");
            if (previousKey == 'd')
            {
                Flip("left");
            }
            transform.Translate(-velocity, 0f, 0f);
            previousKey = 'a';
        }
        if (Input.GetKey("w"))
        {
            walk.SetBool("walking", true);
            walk.Play("walk");
            transform.Translate(0f, velocity, 0f);
        }
        if (Input.GetKey("s"))
        {
            walk.SetBool("walking", true);
            walk.Play("walk");
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
            if (theScale.x < 0)
                theScale.x = -theScale.x;
                 pos.x = pos.x - .1f;
                transform.SetPositionAndRotation((pos), transform.rotation);
        }
        if (flip == "left")
        {
            if (theScale.x > 0)
                theScale.x = -theScale.x;
                pos.x = pos.x + .1f;
                transform.SetPositionAndRotation((pos), transform.rotation);
        }
        transform.localScale = theScale;
    }




}
