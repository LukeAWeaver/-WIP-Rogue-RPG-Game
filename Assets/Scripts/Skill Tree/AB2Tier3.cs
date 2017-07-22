using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AB2Tier3 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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
    private void Update()
    {
        if (player.GetComponent<KnightStats>().AB2KB >= 5f && player.GetComponent<KnightStats>().AB2Radius > 0f)
        {
            GetComponent<Image>().color = Color.white;
        }
        else if (player.GetComponent<KnightStats>().AB2KB >= 5f)
        {
            GetComponent<Image>().color = new Color32(128, 113, 113, 255);
        }
    }
    void A2KB() //ability2 tier 2
    {
        if (player.GetComponent<KnightStats>().AB2Radius < .5f && player.GetComponent<KnightStats>().SkillPoints > 0 && player.GetComponent<KnightStats>().AB2KB >= 5f) //max upgrades is 5
        {
            player.GetComponent<KnightStats>().AB2Radius +=.1f;
            player.GetComponent<KnightStats>().SkillPoints--;
        }
    }
    //tooltip
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<AB2Tier3Description>().gameObject.GetComponent<Text>().text = "Increases Ability 2 radius.";
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<AB2Tier3Description>().gameObject.GetComponent<Text>().text = "";
    }
}
