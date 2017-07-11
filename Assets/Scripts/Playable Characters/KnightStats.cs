using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnightStats : MonoBehaviour {

    public int health;
    public int tempHP;
    public float energy;
    public int exp;
    public int requiredExp;
    public int level;
    public int gold;
    public float timer;
    public bool isRecovering;
    private float resting;
	// Use this for initialization
	void Start () {
        resting = 3;
        exp = 0;
        requiredExp = 3;
        isRecovering = false;
        timer = 0;
        gold = PlayerPrefs.GetInt("gold");
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
        PlayerPrefs.SetInt("gold", gold);
        health = PlayerPrefs.GetInt("currentHP");
        if(health <1)
        {
            SceneManager.LoadScene("OverWorld");
        }
        else
        {
            this.gameObject.SetActive(true);
        }
        if(exp>=requiredExp)
        {
            level++;
            requiredExp = requiredExp + 2;
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
