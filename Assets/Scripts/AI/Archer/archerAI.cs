﻿using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class archerAI : MonoBehaviour
{
    public string flip;
    private GameObject player;
    public MonsterInterface ThisNPCStats;
    public GameObject ThisNPC;
    public bool inSight;
    public float range;
    public int counter;
    public float xVelocity;
    public float yVelocity;

    void Start()
    {
        player = FindObjectOfType<KnightStats>().gameObject;
        ThisNPC = gameObject;
        ThisNPCStats = gameObject.GetComponent<MonsterInterface>();
        counter = 0;
        InvokeRepeating("movement", 0, .03f);
        ThisNPCStats.hp = 3;
        ThisNPCStats.ms = .023f;
    }

    void movement()
    {
        var target = player.transform.position;
        var gp = ThisNPCStats.transform.position;
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
            transform.Translate(xVelocity,0f, yVelocity);
            inSight = false;
            counter++;
        }
    }

    void Update()
    {
        if (ThisNPCStats.hp <= 0)
        {
            ThisNPC.SetActive(false);
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
            if (transform.position.z > target.z)
            {
                transform.Translate(0f, 0f, -0.0001f);
            }
            else
            {
                transform.Translate(0f, 0f,0.0001f);
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
}
