using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPotions : MonoBehaviour {
    //public GameObject player;
    public int hpPot;
    public int currentHP;
    private bool PotionOnCD;
    public Slider potionSlider; 
	// Use this for initialization
	void Start () {
        hpPot = PlayerPrefs.GetInt("hpPots");
        PotionOnCD = false;
        potionSlider.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        PlayerPrefs.SetInt("hpPots",hpPot);
        currentHP = PlayerPrefs.GetInt("currentHP") + 2;
        if (Input.GetKeyDown(KeyCode.T) && hpPot>0 && !PotionOnCD)
        {
            StartCoroutine(UsePotion());
        }
    }
    IEnumerator UsePotion()
    {
        hpPot--;
        PlayerPrefs.SetInt("hpPots", hpPot);
        PlayerPrefs.SetInt("currentHP", currentHP);
        PotionOnCD = true;
        potionSlider.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        potionSlider.value = 4;
        yield return new WaitForSeconds(1f);
        potionSlider.value = 3;
        yield return new WaitForSeconds(1f);
        potionSlider.value = 2;
        yield return new WaitForSeconds(1f);
        potionSlider.value = 1;
        yield return new WaitForSeconds(1f);
        potionSlider.gameObject.SetActive(false);
        potionSlider.value = 5;
        PotionOnCD = false;
    }
}
