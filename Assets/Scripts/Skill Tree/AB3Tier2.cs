using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AB3Tier2 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button sp;
    private GameObject player;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<KnightStats>().gameObject;
        Button btn = sp.GetComponent<Button>();
        btn.onClick.AddListener(A3ATKPWR);

    }
    private void Update()
    {
        if (player.GetComponentInChildren<ability3Script>().AB3dmg >= 5 && player.GetComponentInChildren<ability3Script>().AB3Speed > 0f) //atleast 1 point in current skill
        {
            GetComponent<Image>().color = Color.white;
        }
        else if (player.GetComponentInChildren<ability3Script>().AB3dmg >= 5) //previous skill maxed out
        {
            GetComponent<Image>().color = new Color32(128, 113, 113, 255);
        }
    }
    void A3ATKPWR() //ability3 tier 1
    {
        if (player.GetComponentInChildren<ability3Script>().AB3Speed < .049f && player.GetComponent<KnightStats>().SkillPoints > 0 && player.GetComponentInChildren<ability3Script>().AB3dmg >= 5) //max upgrades is 5
        {
            player.GetComponentInChildren<ability3Script>().AB3Speed +=.01f;
            player.GetComponent<KnightStats>().SkillPoints--;
        }
    }
    //tooltip
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<AB3Tier2Description>().gameObject.GetComponent<Text>().text = "Increases Ability 3 Speed."; 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<AB3Tier2Description>().gameObject.GetComponent<Text>().text = "";
    }
}
