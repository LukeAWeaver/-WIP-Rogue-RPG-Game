using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class archerAI : MonoBehaviour
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

    // Use this for initialization
    void Start()
    {
        counter = 0;
        InvokeRepeating("movement", 0, .03f);
        Thisgoblin.hp = 3;
        Thisgoblin.ms = .023f;
    }

    void movement()
    {
        var target = player.transform.position;
        var gp = Thisgoblin.transform.position;
        range = Mathf.Sqrt((target.x - gp.x) * (target.x - gp.x) + (target.y - gp.y) * (target.y - gp.y));

        if (range < 5)
        {
            inSight = true;
        }
        else
        {
            if (counter % 60 == 0)
            {
                xVelocity = Random.Range(-0.03f, 0.03f);
                if (xVelocity < 0)
                {
                    Flip("right");
                }
                else
                {
                    Flip("left");
                }
                yVelocity = Random.Range(-0.03f, 0.03f);
            }
            transform.Translate(xVelocity, yVelocity, 0f);
            inSight = false;
            counter++;
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (Thisgoblin.hp <= 0)
        {
            npc.SetActive(false);
            player.GetComponent<KnightStats>().exp++;
        }
        var target = player.transform.position;
        if (inSight)
        {
            if (transform.position.x > target.x)
            {
                Flip("right");
                transform.Translate(-0.0001f, 0f, 0f);
            }
            else if (transform.position.x < target.x)
            {
                Flip("left");
                transform.Translate(0.0001f, 0f, 0f);
            }
            if (transform.position.y > target.y)
            {
                transform.Translate(0f, -0.0001f, 0f);
            }
            else
            {
                transform.Translate(0f, 0.0001f, 0f);
            }
        }





    }
    public void Flip(string Methodflip)
    {
        flip = Methodflip;
        var theScale = transform.localScale;
        if (Methodflip == "left")
        {
            if (theScale.x < 0f)
                theScale.x = -theScale.x;
        }
        if (Methodflip == "right")
        {
            if (theScale.x > 0f)
                theScale.x = -theScale.x;
        }
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


    }
}
