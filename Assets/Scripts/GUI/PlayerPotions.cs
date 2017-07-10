using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerPotions : MonoBehaviour {
    //public GameObject player;
    public int hpPot;
    public int currentHP;
	// Use this for initialization
	void Start () {
        hpPot = PlayerPrefs.GetInt("hpPots");
	}
	
	// Update is called once per frame
	void Update () {
        PlayerPrefs.SetInt("hpPots",hpPot);
        currentHP = PlayerPrefs.GetInt("currentHP") + 1;
        if (Input.GetKeyDown(KeyCode.T) && hpPot>0)
        {
            hpPot--;
            PlayerPrefs.SetInt("hpPots", hpPot);
            PlayerPrefs.SetInt("currentHP", currentHP);
            //player.GetComponent<KnightStats>().health++;
        }
	}
}
