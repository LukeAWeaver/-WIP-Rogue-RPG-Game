using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightStats : MonoBehaviour {

    public int health;
    public int tempHP;
    public float energy;
    public int exp;
    public int level;
    public int gold;
    public float timer;
    public bool isRecovering;
    private float resting;
	// Use this for initialization
	void Start () {
        resting = 3;
        exp = 0;
        gold = 0;
        isRecovering = false;
        timer = 0;
        health = 6;
        tempHP = 6;
        energy = 100;
        level = 1;
        InvokeRepeating("resetHP", 0, .03f);
        InvokeRepeating("EnergyRegen", 0, .25f);
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
    public void EnergyRegen()
    {
        if (energy<100 && Input.anyKey && !Input.GetKey("left shift"))
        {
            resting=13;
            energy = energy + .5f;
        }
        else if(energy < 100 && !Input.anyKey)
        {
            if (energy +  Mathf.Log(resting, 10f) > 100)
            {
                energy = 100;
            }
            else
            {
                energy = energy +  Mathf.Log(resting, 10f);
            }
            resting = resting + resting * .9f;
        }
        if(energy>=100)
        {
            resting = 13;
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
