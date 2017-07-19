using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AB1Tier1 : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    public Button sp;
    private GameObject player;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<KnightStats>().gameObject;
        Button btn = sp.GetComponent<Button>();
        btn.onClick.AddListener(SPA1ATKPWR);

    }

    // Update is called once per frame
    void Update()
    {

    }
     void SPA1ATKPWR() //ability1 tier 1
    {
        if (player.GetComponent<KnightStats>().SPBonusATK < 5 && player.GetComponent<KnightStats>().SkillPoints > 0) //max upgrades is 5
        {
            player.GetComponent<KnightStats>().SPBonusATK++;
            player.GetComponent<KnightStats>().SkillPoints--;
        }
    }
    //tooltip
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<AB1Tier1Description>().gameObject.GetComponent<Text>().text = "Increases damage in Ability 1 form."; //waaa this was crazy to code
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<AB1Tier1Description>().gameObject.GetComponent<Text>().text = "";
    }
}
