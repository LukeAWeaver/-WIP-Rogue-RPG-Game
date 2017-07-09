using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ShadowKnightAI : MonoBehaviour
{
    public string flip;
    public GameObject player;
    public MonsterInterface ShadowKnight;
    public GameObject npc;
    public bool inSight;
    public float range;
    public int counter;
    public float xVelocity;
    public float yVelocity;
    private float x;
    private bool isFlippingLeft;
    private bool isFlippingRight;
    // Use this for initialization
    void Start()
    {
        counter = 0;
        InvokeRepeating("movement", 0, .03f);
        ShadowKnight.hp = 6;
        ShadowKnight.ms = .03f;
        x = Mathf.Abs(transform.localScale.x);
        isFlippingRight = false;
        isFlippingLeft = false;
    }

    void movement()
    {
        var target = player.transform.position;
        var gp = ShadowKnight.transform.position;
        range = Mathf.Sqrt((target.x - gp.x) * (target.x - gp.x) + (target.z - gp.z) * (target.z - gp.z));

        if (range < 3.5)
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
                    ShadowKnight.isFlippingLeft = true;
                    ShadowKnight.isFlippingRight = false;
                }
                else
                {
                    ShadowKnight.isFlippingLeft = false;
                    ShadowKnight.isFlippingRight = true;
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
        if (ShadowKnight.hp <= 0)
        {
            player.GetComponent<KnightStats>().exp++; //im a genius
            npc.SetActive(false);
        }
        var target = player.transform.position;
        if (inSight)
        {
            if (transform.position.x > target.x)
            {
                ShadowKnight.isFlippingLeft = true;
                ShadowKnight.isFlippingRight = false;
                transform.Translate(-ShadowKnight.ms, 0f, 0f);
            }
            else if (transform.position.x < target.x)
            {
                ShadowKnight.isFlippingLeft = false;
                ShadowKnight.isFlippingRight = true;
                transform.Translate(ShadowKnight.ms, 0f, 0f);
            }
            if (transform.position.z > target.z)
            {
                transform.Translate(0f, 0f, -ShadowKnight.ms);
            }
            else
            {
                transform.Translate(0f, 0f, ShadowKnight.ms);
            }
        }
        ShadowKnight.CheckFlipping();
    }
}
