using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AI : MonoBehaviour
{
    public string flip;
    public GameObject player;
    public MonsterInterface Thisgoblin;
    public GameObject npc;
    public bool inSight;
    public float range;
    public int counter;
    public float xVelocity;
    public float yVelocity;
    public float sight;
    private float x;

    // Use this for initialization
    void Start () {
        counter = 0;
        InvokeRepeating("movement", 0, .03f);
        Thisgoblin.hp = 3;
        Thisgoblin.ms = .25f;
        Thisgoblin.rotationSpeed = 4f;
        x = Mathf.Abs(transform.localScale.x);
        sight = 3.5f;

    }
    
    void movement ()
    {
        var target = player.transform.position;
        var gp = Thisgoblin.transform.position;
        range = Mathf.Sqrt((target.x - gp.x)* (target.x - gp.x) + (target.z - gp.z)* (target.z - gp.z));

        if( range < sight )
        {
            inSight = true;
        }
        else
        {
            if (counter % 60 ==0)
            {
                xVelocity = Random.Range(-0.02f, 0.02f);
                if(xVelocity <0)
                {
                    Thisgoblin.isFlippingLeft = true;
                    Thisgoblin.isFlippingRight = false;
                }
                else
                {
                    Thisgoblin.isFlippingLeft = false;
                    Thisgoblin.isFlippingRight = true;
                }
                yVelocity = Random.Range(-0.02f, 0.02f);
            }
            transform.Translate(xVelocity, 0f, yVelocity);
            inSight = false;
            counter++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Thisgoblin.hp <=0)
        {
            player.GetComponent<KnightStats>().exp++; //im a genius
            npc.SetActive(false);
        }
        if(Thisgoblin.hp == 1)
        {
            Thisgoblin.ms = .2f;
        }
        var target = player.transform.position;
        if (inSight)
        {
            if (transform.position.x > (target.x + .6f))
            {
                Thisgoblin.isFlippingLeft = true;
                Thisgoblin.isFlippingRight = false;
                if(GetComponent<Rigidbody>().velocity.x > -3f)
                GetComponent<Rigidbody>().velocity += new Vector3(-Thisgoblin.ms, 0f, 0f);
            }
            else if (transform.position.x < (target.x - .6f))
            {
                Thisgoblin.isFlippingLeft = false;
                Thisgoblin.isFlippingRight = true;
                if (GetComponent<Rigidbody>().velocity.x < 3f)
                    GetComponent<Rigidbody>().velocity += new Vector3(Thisgoblin.ms, 0f, 0f);
            }
            if (transform.position.z > (target.z+.01f) && GetComponent<Rigidbody>().velocity.z > -3f)
            {
                GetComponent<Rigidbody>().velocity += new Vector3(0f, 0f, -Thisgoblin.ms);
            }
            else if (transform.position.z < (target.z -.01f) && GetComponent<Rigidbody>().velocity.z < 3f)
            {
                GetComponent<Rigidbody>().velocity += new Vector3(0f, 0f, Thisgoblin.ms);
            }
            sight = 7f;
        }
        sight = 3.5f;
        Thisgoblin.CheckFlipping();
    }




}
