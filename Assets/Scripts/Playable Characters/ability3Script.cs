using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ability3Script : MonoBehaviour
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
        swing = GetComponent<Animator>();
        var offset = knight.transform.position;
        var theScale = transform.localScale;
        if (knight.GetComponentInChildren<ability1Script>().isActiveToggle == 1)
            theScale = new Vector3(1, 1, 1);
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
        speed = knight.GetComponent<KnightStats>().movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (test == 0 && swing.GetCurrentAnimatorStateInfo(0).IsName("default"))
        {
            gameObject.GetComponent<Collider>().enabled = true;
            swing.SetBool("ability3", true);
            test++;
            knight.GetComponent<KnightStats>().energy = knight.GetComponent<KnightStats>().energy - 10;
        }
        else if (test == 1 && swing.GetCurrentAnimatorStateInfo(0).IsName("ability3Release") && knight.GetComponent<KnightStats>().energy >= 10)
        {
            swing.SetBool("ability3", false);
            test = 2;
            gameObject.GetComponent<Collider>().enabled = false;
        }
        if (!direction)
            transform.Translate(-speed, 0f, 0f);
        else if (direction)
        {
            transform.Translate(speed, 0f, 0f);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<MonsterInterface>() != null)
        {
            if (collision.gameObject.GetComponent<MonsterInterface>().hp > 1)
                collision.gameObject.GetComponent<MonsterInterface>().hp = collision.gameObject.GetComponent<MonsterInterface>().hp - 2 * knight.GetComponent<KnightStats>().AD;
            else
            {
                collision.gameObject.GetComponent<MonsterInterface>().hp--;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<MonsterInterface>() != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

}
