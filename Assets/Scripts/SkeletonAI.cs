﻿using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SkeletonAI : MonoBehaviour
{
    public string flip;
    public GameObject player;
    public MonsterInterface ThisNPCStats;
    public GameObject ThisNPC;
    public bool inSight;
    public float range;
    public int counter;
    public float xVelocity;
    public float yVelocity;
    public float sight;
    private float x;

    // Use this for initialization
    void Start()
    {
        ThisNPC = gameObject;
        ThisNPCStats = gameObject.GetComponent<MonsterInterface>();
        player = FindObjectOfType<KnightStats>().gameObject;
        counter = 0;
        InvokeRepeating("movement", 0, .03f);
        ThisNPCStats.hp = 1;
        ThisNPCStats.ms = .4f;
        ThisNPCStats.rotationSpeed = 2f;
        x = Mathf.Abs(transform.localScale.x);
        sight = 5f;

    }

    void movement()
    {
        var target = player.transform.position;
        var gp = ThisNPCStats.transform.position;
        range = Mathf.Sqrt((target.x - gp.x) * (target.x - gp.x) + (target.z - gp.z) * (target.z - gp.z));

        if (range < sight)
        {
            inSight = true;
        }
        else
        {
            if (counter % 60 == 0)
            {
                xVelocity = Random.Range(-0.02f, 0.02f);
                if (xVelocity < 0)
                {
                    ThisNPCStats.isFlippingLeft = true;
                    ThisNPCStats.isFlippingRight = false;
                }
                else
                {
                    ThisNPCStats.isFlippingLeft = false;
                    ThisNPCStats.isFlippingRight = true;
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
        if (ThisNPCStats.hp <= 0)
        {
            //player.GetComponent<KnightStats>().exp++; //im a genius
            ThisNPC.SetActive(false);
        }

        var target = player.transform.position;
        if (inSight)
        {
            if (transform.position.x > (target.x + .6f))
            {
                ThisNPCStats.isFlippingLeft = true;
                ThisNPCStats.isFlippingRight = false;
                if (GetComponent<Rigidbody>().velocity.x > -3f)
                    GetComponent<Rigidbody>().velocity += new Vector3(-ThisNPCStats.ms, 0f, 0f);
            }
            else if (transform.position.x < (target.x - .6f))
            {
                ThisNPCStats.isFlippingLeft = false;
                ThisNPCStats.isFlippingRight = true;
                if (GetComponent<Rigidbody>().velocity.x < 3f)
                    GetComponent<Rigidbody>().velocity += new Vector3(ThisNPCStats.ms, 0f, 0f);
            }
            if(Mathf.Abs(transform.position.z - player.transform.position.z) <.01f)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 0f, 0f);
            }
            else if (transform.position.z > (target.z + .01f) && GetComponent<Rigidbody>().velocity.z > -3f)
            {
                GetComponent<Rigidbody>().velocity += new Vector3(0f, 0f, -ThisNPCStats.ms);
            }
            else if (transform.position.z < (target.z - .01f) && GetComponent<Rigidbody>().velocity.z < 3f)
            {
                GetComponent<Rigidbody>().velocity += new Vector3(0f, 0f, ThisNPCStats.ms);
            }
            sight = 10f;
        }
        else
        {
            sight = 5f;
        }
        ThisNPCStats.CheckFlipping();
    }




}