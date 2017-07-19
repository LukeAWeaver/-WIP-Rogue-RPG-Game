using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AB1Tier3 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button sp;
    private GameObject player;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<KnightStats>().gameObject;
        Button btn = sp.GetComponent<Button>();
        btn.onClick.AddListener(SPA1MS);

    }

    // Update is called once per frame
    void Update()
    {

    }
    void SPA1MS() //ability1 tier 2
    {
        if (player.GetComponent<KnightStats>().SPBonusScale < .15f && player.GetComponent<KnightStats>().SkillPoints > 0) //max upgrades is 3
        {
            player.GetComponent<KnightStats>().SPBonusScale = .05f + player.GetComponent<KnightStats>().SPBonusScale;
            player.GetComponent<KnightStats>().SkillPoints--;
        }
    }
    //tooltip
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<AB1Tier3Description>().gameObject.GetComponent<Text>().text = "Expands player Size, increasing attack range."; //waaa this was crazy to code
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<AB1Tier3Description>().gameObject.GetComponent<Text>().text = "";
    }
}
