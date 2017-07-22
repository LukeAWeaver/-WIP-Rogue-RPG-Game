using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AB3Tier3 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button sp;
    private GameObject player;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<KnightStats>().gameObject;
        Button btn = sp.GetComponent<Button>();
        btn.onClick.AddListener(A3Duration);
    }
    private void Update()
    {
        if (player.GetComponentInChildren<ability3Script>().AB3Speed >= .049f && player.GetComponentInChildren<ability3Script>().AB3duration > 0f) //atleast 1 point in current skill
        {
            GetComponent<Image>().color = Color.white;
        }
        else if (player.GetComponentInChildren<ability3Script>().AB3Speed >= .049f) //previous skill maxed out
        {
            GetComponent<Image>().color = new Color32(128, 113, 113, 255);
        }
    }
    void A3Duration() //ability3 tier 3
    {
        if (player.GetComponentInChildren<ability3Script>().AB3duration < 1.49f && player.GetComponent<KnightStats>().SkillPoints > 0 && player.GetComponentInChildren<ability3Script>().AB3Speed >= .049f) //max upgrades is 5
        {
            player.GetComponentInChildren<ability3Script>().AB3duration += .5f;
            player.GetComponent<KnightStats>().SkillPoints--;
        }
    }
    //tooltip
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<AB3Tier3Description>().gameObject.GetComponent<Text>().text = "Increases duration of Ability 3.";
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<AB3Tier3Description>().gameObject.GetComponent<Text>().text = "";
    }
}
