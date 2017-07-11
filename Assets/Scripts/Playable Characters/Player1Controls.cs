using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controls : MonoBehaviour
{
    public float velocity = .05f;
    public float fallMultiplier = 1.5f;
    public float lowJumpMultiplier = 1f;
    private bool isMoving;
    private bool isRunning;
    public GameObject autoAttack;
    public char previousKey;
    public bool isFlippingLeft;
    public bool isFlippingRight;
    public bool onGround;
    private Rigidbody rb;
    Animator walk;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isMoving = false;
        walk = GetComponent<Animator>();
        previousKey = 'd';
        onGround = true;
    }

    void Update()
    {
        walk.SetBool("walking", false); // used for animation
        // BEING JUMPING SCRIPT
        if(Input.GetKeyDown(KeyCode.Space) && gameObject.GetComponent<KnightStats>().energy > 5 && onGround)
        {
            gameObject.GetComponent<KnightStats>().energy = gameObject.GetComponent<KnightStats>().energy - 5;
            rb.velocity = new Vector3(0f, 5f, 0f);
            onGround = false;
        }
        if(rb.velocity.y <0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier) * Time.deltaTime;
        }
        else if(rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        //END JUMPING SCRIPT
        if (gameObject.GetComponent<KnightStats>().energy > 0)
        {
            CheckWalking();
            CheckRunning();
            if (!isRunning)
            {
                CheckRoll();
            }
            //BASIC INPUT
            if (Input.GetKey("d"))
            {

                if (previousKey == 'a')
                {
                    isFlippingLeft = false;
                    isFlippingRight = true;
                }
                transform.Translate(velocity, 0f, 0f);
                previousKey = 'd';
            }
            if (Input.GetKey("a"))
            {
                if (previousKey == 'd')
                {
                    isFlippingLeft = true;
                    isFlippingRight = false;
                }
                transform.Translate(-velocity, 0f, 0f);
                previousKey = 'a';
            }
            if (Input.GetKey("w"))
            {
                transform.Translate(0f, 0f, velocity);
            }
            if (Input.GetKey("s"))
            {
                transform.Translate(0f, 0f, -velocity);
            }
            if (isMoving && isRunning && Input.GetKey("left shift"))
            {
                walk.SetBool("shift", true);
                gameObject.GetComponent<KnightStats>().energy = gameObject.GetComponent<KnightStats>().energy - .05f;
            }
        }
        CheckFlipping();


    }
    public void CheckRunning()
    {
        if (Input.GetKey("left shift") && (Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("w") || Input.GetKey("s")))
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
            if (walk.GetBool("roll") == false)
                velocity = 0.02f;
        }
    }
    public void CheckRoll()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && gameObject.GetComponent<KnightStats>().energy >= 20)
        {
            if (!walk.GetCurrentAnimatorStateInfo(0).IsName("roll"))
            {
                gameObject.GetComponent<KnightStats>().energy = gameObject.GetComponent<KnightStats>().energy - 20;
            }
            walk.SetBool("roll", true);
            velocity = 0.1f;
        }
        if (walk.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !walk.IsInTransition(0))
        {
            walk.SetBool("roll", false);
        }
    }
    public void CheckFlipping()
    {
        //FLIPPING LEFT
        if (isFlippingLeft && transform.localScale.x > -.40f)
        {
            float rotationSpeed = 5.0f;
            Vector3 rot = transform.localScale;
            rot.x = rot.x + -rotationSpeed * Time.deltaTime;
            transform.localScale = rot;

        }
        else if (isFlippingLeft && transform.localScale.x <= -.41f)
        {
            Vector3 rot = transform.localScale;
            rot.x = -.41f;
            transform.localScale = rot;
        }
        //FLIPPING RIGHT
        if (isFlippingRight && transform.localScale.x < .40f)
        {
            float rotationSpeed = 5.0f;
            Vector3 rot = transform.localScale;
            rot.x = rot.x + rotationSpeed * Time.deltaTime;
            transform.localScale = rot;

        }
        else if (isFlippingRight && transform.localScale.x >= .41f)
        {
            Vector3 rot = transform.localScale;
            rot.x = .41f;
            transform.localScale = rot;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Scenery" || collision.gameObject.tag == "npc" )
        {
            onGround = true;
        }
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
