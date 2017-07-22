using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AB3T4 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button sp;
    private GameObject player;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<KnightStats>().gameObject;
        Button btn = sp.GetComponent<Button>();
        btn.onClick.AddListener(AB3Ultimate);
    }
    private void Update()
    {
        if (player.GetComponentInChildren<ability3Script>().AB3duration >= 1.5f && player.GetComponentInChildren<ability3Script>().AB3Ultimate == 1) //atleast 1 point in current skill
        {
            GetComponent<Image>().color = Color.white;
        }
        else if (player.GetComponentInChildren<ability3Script>().AB3duration >= 1.5f) //previous skill maxed out
        {
            GetComponent<Image>().color = new Color32(128, 113, 113, 255);
        }
    }
    void AB3Ultimate() //ability3 tier 4
    {
        if (player.GetComponentInChildren<ability3Script>().AB3Ultimate < 1 && player.GetComponent<KnightStats>().SkillPoints > 0 && player.GetComponentInChildren<ability3Script>().AB3duration >=1.5f) //max upgrades is 5
        {
            player.GetComponentInChildren<ability3Script>().AB3Ultimate = 1;
            player.GetComponent<KnightStats>().SkillPoints--;
        }
    }
    //tooltip
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<AB3Tier4Description>().gameObject.GetComponent<Text>().text = "Fires 2 more projectiles.";
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<AB3Tier4Description>().gameObject.GetComponent<Text>().text = "";
    }
}
