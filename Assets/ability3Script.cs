using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ability3Script : MonoBehaviour {

    public GameObject knight;
    Animator swing;
    public int test;
    // Use this for initialization
    void Start () {
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
            offset.x = offset.x - 1f;
            theScale.x = -theScale.x;
        }
        else
        {
            offset.x = offset.x + 1f;
        }
        transform.localScale = theScale;
        transform.position = offset;
    }

    // Update is called once per frame
    void Update () {

            if (test == 0 && swing.GetCurrentAnimatorStateInfo(0).IsName("default"))
            {
                gameObject.GetComponent<Collider2D>().enabled = true;
                swing.SetBool("ability3", true);
                test++;
            }
            else if (test == 1 && swing.GetCurrentAnimatorStateInfo(0).IsName("ability3Release") && knight.GetComponent<KnightStats>().energy >=10)
            {
            knight.GetComponent<KnightStats>().energy = knight.GetComponent<KnightStats>().energy - 10;
                swing.SetBool("ability3", false);
                test = 2;

                gameObject.GetComponent<Collider2D>().enabled = false;
            }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MonsterInterface>() != null)
        {
            if(collision.gameObject.GetComponent<MonsterInterface>().hp>1)
            collision.gameObject.GetComponent<MonsterInterface>().hp = collision.gameObject.GetComponent<MonsterInterface>().hp - 2;
            else
            {
                collision.gameObject.GetComponent<MonsterInterface>().hp--;
            }
        }
    }

}
