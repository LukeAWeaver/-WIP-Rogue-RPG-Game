using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AB1Tier2 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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
        if (player.GetComponent<KnightStats>().SPBonusMS < .010f && player.GetComponent<KnightStats>().SkillPoints > 0) //max upgrades is 5
        {
            player.GetComponent<KnightStats>().SPBonusMS  = .002f + player.GetComponent<KnightStats>().SPBonusMS;
            player.GetComponent<KnightStats>().SkillPoints--;
        }
    }
    //tooltip
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<AB1Tier2Description>().gameObject.GetComponent<Text>().text = "Increases Movement Speed."; //waaa this was crazy to code
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<AB1Tier2Description>().gameObject.GetComponent<Text>().text = "";
    }
}
