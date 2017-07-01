using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightStats : MonoBehaviour {

    public int health;
    public int tempHP;
    public int energy;
    public int exp;
    public int level;
    public float timer;
    public bool isRecovering;
	// Use this for initialization
	void Start () {
        exp = 0;
        isRecovering = false;
        timer = 0;
        health = 6;
        tempHP = 6;
        energy = 100;
        level = 1;
        InvokeRepeating("resetHP", 0, .03f);
    }

    // Update is called once per frame
    void Update ()
    {
        if(health <1)
        {
            this.gameObject.SetActive(false);
        }
        if(exp>9)
        {
            level++;
            exp = 0;
        }
	}

    public void resetHP()
    {
        if (isRecovering)
        {
            if(timer < 30)
            {
                if(timer%6 == 0)
                {
                    GetComponent<SpriteRenderer>().color = Color.gray;
                }
                else
                {
                    GetComponent<SpriteRenderer>().color = Color.white;
                }
                timer++;
            }
            else
            {
                timer = 0;
                isRecovering = false;
            }
     
            
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
}
