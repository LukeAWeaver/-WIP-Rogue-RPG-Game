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
    public int SkillPoints;
    public int gold;
    public float timer;
    public float currentEXP;
    public bool isRecovering;
    private float resting;
    public Slider expBar;
    public int AD=0;
    public GameObject[] weapon;
    public int currentWeapon;
    public int Ab1;
    public int SPBonusATK;
    public float SPBonusMS;
    public float SPBonusScale;
    public int AB2BonusATK;
    public float AB2KB;
    public float AB2Radius;
    public int AB2Ultimate;
    public int AB4BonusATK;
    public float AB4KB;
    public string AB4Stun;
    public string AB4Ultimate;
    public int UnlockAB1;
    public int UnlockAB2;
    public int UnlockAB3;
    public int UnlockAB4;

    public GameObject Ability3;

    // Use this for initialization
    private void Awake()
    {
        Ability3 = Resources.Load("Ability3") as GameObject;
        Ability3.GetComponent<ability3Script>().AB3dmg = PlayerPrefs.GetInt("AB3dmg");
        Ability3.GetComponent<ability3Script>().AB3Speed = PlayerPrefs.GetFloat("AB3Speed");
        Ability3.GetComponent<ability3Script>().AB3duration = PlayerPrefs.GetFloat("AB3duration");
        Ability3.GetComponent<ability3Script>().AB3Ultimate = PlayerPrefs.GetInt("AB3Ultimate");
    }
    void Start()
    {
        Ab1 = 1;
        resting = 3;
        exp = 0;
        timer = 0;
        health = 6;
        tempHP = 6;
        energy = 10000;
        isRecovering = false;


        currentWeapon = PlayerPrefs.GetInt("currentWeapon");
        if(currentWeapon == 1)
        {
            weapon[0].SetActive(true);
            weapon[1].SetActive(true);
            weapon[2].SetActive(false);
            weapon[3].SetActive(false);
        }
        else if(currentWeapon == 2)
        {
            weapon[0].SetActive(false);
            weapon[1].SetActive(false);
            weapon[2].SetActive(true);
            weapon[3].SetActive(false);
        }
        else if (currentWeapon == 3)
        {
            weapon[0].SetActive(true);
            weapon[1].SetActive(false);
            weapon[2].SetActive(false);
            weapon[3].SetActive(true);
        }
        gold = PlayerPrefs.GetInt("gold");
        level = PlayerPrefs.GetInt("level");
        requiredExp = level + 3;
        SkillPoints = PlayerPrefs.GetInt("SP");
        movementSpeed = PlayerPrefs.GetFloat("ms");
        critChance = PlayerPrefs.GetFloat("critChance");
        attackSpeed = PlayerPrefs.GetFloat("atkSpeed");
        SPBonusATK = PlayerPrefs.GetInt("SPBonusATK");
        SPBonusMS = PlayerPrefs.GetFloat("SPBonusMS");
        SPBonusScale = PlayerPrefs.GetFloat("SPBonusScale");
        //ability2
        AB2BonusATK = PlayerPrefs.GetInt("AB2BonusATK");
        AB2KB = PlayerPrefs.GetFloat("AB2KB");
        AB2Radius = PlayerPrefs.GetFloat("AB2Radius");
        AB2Ultimate = PlayerPrefs.GetInt("AB2Ultimate");
        //ability 4
        AB4BonusATK = PlayerPrefs.GetInt("AB4BonusATK");
        AB4KB = PlayerPrefs.GetFloat("AB4KB");
        AB4Stun = PlayerPrefs.GetString("AB4Stun");
        AB4Ultimate= PlayerPrefs.GetString("AB4Ultimate");

        UnlockAB1 = PlayerPrefs.GetInt("UnlockAB1");
        UnlockAB2 = PlayerPrefs.GetInt("UnlockAB2");
        UnlockAB3 = PlayerPrefs.GetInt("UnlockAB3");
        UnlockAB4 = PlayerPrefs.GetInt("UnlockAB4");

        InvokeRepeating("resetHP", 0, .03f);
        InvokeRepeating("EnergyRegen", 0, .25f);
        expBar = FindObjectOfType<xpbarIdentifier>().gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update ()
    {
        currentEXP = (float)exp / (float)requiredExp;
        expBar.value = currentEXP;
        PlayerPrefs.SetInt("gold", gold);
        PlayerPrefs.SetInt("currentWeapon", currentWeapon);
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("SP", SkillPoints);
        PlayerPrefs.SetInt("SPBonusATK", SPBonusATK);
        PlayerPrefs.SetFloat("SPBonusMS", SPBonusMS);
        PlayerPrefs.SetFloat("SPBonusScale", SPBonusScale);
        PlayerPrefs.SetFloat("ms", movementSpeed);
        PlayerPrefs.SetFloat("critChance", critChance);
        PlayerPrefs.SetFloat("atkSpeed", attackSpeed);
        //ab2
        PlayerPrefs.SetInt("AB2BonusATK", AB2BonusATK);
        PlayerPrefs.SetFloat("AB2KB", AB2KB);
        PlayerPrefs.SetFloat("AB2Radius", AB2Radius);
        PlayerPrefs.SetInt("AB2Ultimate", AB2Ultimate);
        //ab3
        PlayerPrefs.SetInt("AB3dmg", Ability3.GetComponent<ability3Script>().AB3dmg);
        PlayerPrefs.SetFloat("AB3Speed", Ability3.GetComponent<ability3Script>().AB3Speed);
        PlayerPrefs.SetFloat("AB3duration", Ability3.GetComponent<ability3Script>().AB3duration);
        PlayerPrefs.SetInt("AB3Ultimate", Ability3.GetComponent<ability3Script>().AB3Ultimate);
        //ab4
        PlayerPrefs.SetInt("AB4BonusATK", AB4BonusATK);
        PlayerPrefs.SetFloat("AB4KB", AB4KB);
        PlayerPrefs.SetString("AB4Stun", AB4Stun);
        PlayerPrefs.SetString("AB4Ultimate", AB4Ultimate);
        PlayerPrefs.SetInt("UnlockAB1", UnlockAB1);
        PlayerPrefs.SetInt("UnlockAB2", UnlockAB2);
        PlayerPrefs.SetInt("UnlockAB3", UnlockAB3);
        PlayerPrefs.SetInt("UnlockAB4", UnlockAB4);
        health = PlayerPrefs.GetInt("currentHP");
        if(PlayerPrefs.GetInt("currentHP")>12)
        {
            PlayerPrefs.SetInt("currentHP", 12);
        }
        if (health <1)
        {
            SceneManager.LoadScene("OverWorld");
        }
        if(exp>=requiredExp)
        {
            level++;
            SkillPoints++;
            requiredExp = requiredExp + level;
            exp = 0;
        }
        if(weapon[0].activeInHierarchy)
        {
            if (Ab1 == 2)
                AD = 1 * Ab1 + SPBonusATK;
            else
                AD = 1;
        }
        else if(weapon[2].activeInHierarchy)
        {
            if (Ab1 == 2)
                AD = 2 * Ab1 + SPBonusATK;
            else
                AD = 2;
            
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
                    if(Ab1 < 1.5)
                    GetComponent<SpriteRenderer>().color = Color.gray;
                }
                else
                {
                    if(Ab1 < 1.5)
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
