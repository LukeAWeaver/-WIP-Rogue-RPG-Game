using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwing : MonoBehaviour {
    Animator swing;
    public AudioClip swinging;
    public AudioClip ability3;
    public AudioClip hittingWood;
    public GameObject ab3;
    public GameObject player;
    private AudioSource source;
    public int test;

    // Use this for initialization
    void Start () {
        swing = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        test = 0;
        gameObject.GetComponent<BoxCollider>().enabled = false;

    }

    // Update is called once per frame
    void Update ()
    {
        if(Input.GetKey("3") && player.GetComponent<KnightStats>().energy>=10)
        {
            if (swing.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                source.clip = ability3;
                source.Play();
                swing.Play("Ability3");
                swing.SetInteger("state", 3);
                test=1;
            }
            else if (swing.GetCurrentAnimatorStateInfo(0).IsName("Ability3") && test == 1)
            {
                swing.SetInteger("state", 4);
                test++;
            }
            else if (swing.GetCurrentAnimatorStateInfo(0).IsName("Ability3Hold") && test == 2)
            {
                swing.SetInteger("state", 1);
                var swordSwing = Instantiate(ab3, transform.position, transform.rotation);
                swordSwing.gameObject.GetComponent<ability3Script>().test = 0;

                test++;
            }
            else if (swing.GetCurrentAnimatorStateInfo(0).IsName("Ability3Hold") && test == 3)
            {
                swing.SetInteger("state", 0);
            }

        }





        else if (Input.GetMouseButtonDown(0) && GetComponentInParent<KnightStats>().energy > 0)
        {
            GetComponentInParent<KnightStats>().energy --;
            GetComponent<Collider>().enabled = true;
            swing.SetInteger("state", 1);
            source.clip = swinging;
            if (swing.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !swing.IsInTransition(0))
                source.Play();

        }

        else if (Input.GetMouseButtonUp(0))
        {
            GetComponent<Collider>().enabled = false;
            new WaitForSeconds(2);
            swing.SetInteger("state", 0);
        }
        else if (!(Input.GetKey("a") && Input.GetKey("d")) && (Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("w") || Input.GetKey("s")) && !(Input.GetKey("s") && Input.GetKey("w")))
        {
            swing.SetInteger("state", 2);
        }
        else
            swing.SetInteger("state", 0);
    }
    //handles collisions
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.GetComponent<MonsterInterface>() != null)
        {
            CombatTextManager.Instance.CreateText(collision.transform.position);

            collision.gameObject.GetComponent<MonsterInterface>().hp = collision.gameObject.GetComponent<MonsterInterface>().hp -player.GetComponent<KnightStats>().AD;
            if (player.GetComponent<Player1Controls>().isFlippingLeft)
            {
                collision.GetComponent<Rigidbody>().velocity += new Vector3(-player.GetComponent<Player1Controls>().Ab1*10f, 0f, 0f);
            }
            if (player.GetComponent<Player1Controls>().isFlippingRight)
            {
                collision.GetComponent<Rigidbody>().velocity += new Vector3(player.GetComponent<Player1Controls>().Ab1 * 10f, 0f, 0f);
            }

        }
    }
    private void OnCollisionExit(Collision collision)
    {

    }
}
