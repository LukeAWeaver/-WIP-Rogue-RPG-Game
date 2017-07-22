using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AB2Tier4 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button sp;
    private GameObject player;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<KnightStats>().gameObject;
        Button btn = sp.GetComponent<Button>();
        btn.onClick.AddListener(A2KB);

    }

    void A2KB() //ability2 tier 2
    {
        if (player.GetComponent<KnightStats>().AB2Ultimate < 1 && player.GetComponent<KnightStats>().SkillPoints > 0) //max upgrades is 5
        {
            player.GetComponent<KnightStats>().AB2Ultimate += 1;
            player.GetComponent<KnightStats>().SkillPoints--;
        }
    }
    //tooltip
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<AB2Tier4Description>().gameObject.GetComponent<Text>().text = "Using this ability regenerates a heart for the player.";
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<AB2Tier4Description>().gameObject.GetComponent<Text>().text = "";
    }
}
