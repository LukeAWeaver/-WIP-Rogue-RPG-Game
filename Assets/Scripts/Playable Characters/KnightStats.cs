using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KnightStats : MonoBehaviour {

    public int health;
    public float energy;
    public float attackSpeed;
    public int lifeSteal;
    public float critChance;
    public float movementSpeed;
    public int tempHP;
    public int exp;
    public int requiredExp;
    public int level;
    public int gold;
    public float timer;
    public float currentEXP;
    public bool isRecovering;
    private float resting;
    public Slider expBar;
	// Use this for initialization
  public int AD=0;
  public GameObject[] weapon;
  public int Ab1;

	void Start ()
  {
        Ab1=1;
        resting = 3;
        exp = 0;
        timer = 0;
        requiredExp = level + 3;
        health = 6;
        tempHP = 6;
        energy = 10000;
        isRecovering = false;
        gold = PlayerPrefs.GetInt("gold");
        level = PlayerPrefs.GetInt("level");
        movementSpeed = PlayerPrefs.GetFloat("ms");
        critChance = PlayerPrefs.GetFloat("critChance");
        attackSpeed = PlayerPrefs.GetFloat("atkSpeed");
        InvokeRepeating("resetHP", 0, .03f);
        InvokeRepeating("EnergyRegen", 0, .25f);
    }

    // Update is called once per frame
    void Update ()
    {
        currentEXP = (float)exp / (float)requiredExp;
        expBar.value = currentEXP;
        PlayerPrefs.SetInt("gold", gold);
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetFloat("ms", movementSpeed);
        PlayerPrefs.SetFloat("critChance", critChance);
        PlayerPrefs.SetFloat("atkSpeed", attackSpeed);
        health = PlayerPrefs.GetInt("currentHP");
        if(health <1)
        {
            SceneManager.LoadScene("OverWorld");
        }

        if(exp>=requiredExp)
        {
            level++;
            requiredExp = requiredExp + level;
            exp = 0;
        }
        if(weapon[1].activeInHierarchy)
        {
            AD = 1*Ab1;
        }
        else if(weapon[2].activeInHierarchy)
        {
          AD = 2*Ab1;
        }
      }

    //Regenerating energy algorithm when walking or standing still
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

    //invulnerability code after getting hit
    public void resetHP()
    {
        if (isRecovering)
        {
            if(timer < 30)
            {
                if(timer%12 == 0 || timer % 12 == 1 || timer % 12 == 2 || timer % 12 == 3)
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
}
