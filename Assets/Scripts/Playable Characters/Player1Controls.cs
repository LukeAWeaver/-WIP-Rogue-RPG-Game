using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controls : MonoBehaviour
{
    public float velocity = .05f;
    private bool isMoving;
    private bool isRunning;
    public GameObject autoAttack;
    public string flip;
    public char previousKey;
    Animator walk;

    // Use this for initialization
    void Start()
    {
        isMoving = false;
        walk = GetComponent<Animator>();
        previousKey = 'd';
    }

    // Update is called once per frame
    void Update()
    {
        walk.SetBool("walking", false);
        
        if (gameObject.GetComponent<KnightStats>().energy > 0)
        {
            CheckWalking();
            CheckRunning();
            if(!isRunning)
            {
                CheckRoll();
            }
            if (Input.GetKey("d"))
            {
                if (previousKey == 'a')
                {
                    Flip("left");
                }
                transform.Translate(velocity, 0f, 0f);
                previousKey = 'd';
            }
            if (Input.GetKey("a"))
            {
                if (previousKey == 'd')
                {
                    Flip("right");
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
            if (isMoving && isRunning && Input.GetKey("left shift"))
            {
                walk.SetBool("shift", true);
                gameObject.GetComponent<KnightStats>().energy = gameObject.GetComponent<KnightStats>().energy - .05f;
            }
        }
    }
    public void CheckRunning()
    {
        if (Input.GetKey("left shift") && (Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("w") || Input.GetKey("s")) )
        {
            isRunning = true;
            velocity = 0.05f;
        }
        else
        {
            isRunning = false;
            walk.SetBool("shift", false);
        }
    }
    public void CheckWalking()
    {
        if (!(Input.GetKey("a") && Input.GetKey("d")) && !(Input.GetKey("s") && Input.GetKey("w")) && (Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("w") || Input.GetKey("s")))
        {
            isMoving = true;
            walk.SetBool("walking", true);
            if(walk.GetBool("roll") == false)
            velocity = 0.02f;
        }
    }
    public void CheckRoll()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && gameObject.GetComponent<KnightStats>().energy >=20)
        {
            walk.SetBool("roll", true);
            velocity = 0.1f;
            gameObject.GetComponent<KnightStats>().energy = gameObject.GetComponent<KnightStats>().energy - 20;
        }
        if (walk.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !walk.IsInTransition(0))
        {
            walk.SetBool("roll", false);
        }
    }
    public void Flip(string methodFlip)
    {
        var pos = transform.position;
        flip = methodFlip;
        var theScale = transform.localScale;
        if (flip == "left")
        {
            if (theScale.x < 0)
                theScale.x = -theScale.x;
                 pos.x = pos.x - .1f;
                transform.SetPositionAndRotation((pos), transform.rotation);
        }
        if (flip == "right")
        {
            if (theScale.x > 0)
                theScale.x = -theScale.x;
                pos.x = pos.x + .1f;
                transform.SetPositionAndRotation((pos), transform.rotation);
        }
        transform.localScale = theScale;
    }

}
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
