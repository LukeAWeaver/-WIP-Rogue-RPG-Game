using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SKAbility3: MonoBehaviour
{

    public GameObject knight;
    Animator swing;
    public int test;
    private bool direction;
    private float speed;
    // Use this for initialization
    void Start()
    {
        test = 0;
        //  else
        //  {
        //      transform.localScale = -trans
        //  }
        var offset = knight.transform.position;
        swing = GetComponent<Animator>();
        var theScale = transform.localScale;
        if (knight.transform.localScale.x < 0f)
        {
            offset.x = offset.x - .01f;
            theScale.x = -theScale.x;
            direction = false;
        }
        else
        {
            offset.x = offset.x + .01f;
            direction = true;
        }
        offset.y = offset.y + .5f;
        transform.localScale = theScale;
        transform.position = offset;
        speed = knight.GetComponent<ShadowKnightAI>().ShadowKnight.ms * 2;
    }

    // Update is called once per frame
    void Update()
    {

        if (test == 0 && swing.GetCurrentAnimatorStateInfo(0).IsName("default"))
        {
            gameObject.GetComponent<Collider>().enabled = true;
            swing.SetBool("ability3", true);
            test++;
        }

        if (!direction)
            transform.Translate(-speed, 0f, 0f);
        else if (direction)
        {
            transform.Translate(speed, 0f, 0f);
        }
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.name == "Knight_Player")
        {

            swing.SetBool("inProx", true);
            if (collision.gameObject.GetComponent<KnightStats>().isRecovering)
            {

            }
            else
            {
                CombatTextManager.Instance.CreateText(collision.transform.position);
                collision.gameObject.GetComponent<KnightStats>().health--; //im a genius
                collision.gameObject.GetComponent<KnightStats>().isRecovering = true; //im a genius

            }

            collision.gameObject.GetComponent<KnightStats>().tempHP = collision.gameObject.GetComponent<KnightStats>().health;
        }
        else
        {
        }
    }


}
