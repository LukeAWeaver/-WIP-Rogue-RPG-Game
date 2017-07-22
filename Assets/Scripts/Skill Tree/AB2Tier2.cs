using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AB2Tier2 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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
        if (player.GetComponent<KnightStats>().AB2KB < 5f && player.GetComponent<KnightStats>().SkillPoints > 0) //max upgrades is 5
        {
            player.GetComponent<KnightStats>().AB2KB++;
            player.GetComponent<KnightStats>().SkillPoints--;
        }
    }
    //tooltip
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<AB2Tier2Description>().gameObject.GetComponent<Text>().text = "Increases Ability 2 Knockback.";
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<AB2Tier2Description>().gameObject.GetComponent<Text>().text = "";
    }
}
