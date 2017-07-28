using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AB4 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button sp;
    private GameObject player;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<KnightStats>().gameObject;
        Button btn = sp.GetComponent<Button>();
        btn.onClick.AddListener(AB4Unlock);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<KnightStats>().UnlockAB4 == 1)
        {
            GetComponent<Image>().color = Color.white;
        }
        else
        {
            GetComponent<Image>().color = new Color32(128, 113, 113, 255);
        }
    }
    void AB4Unlock() //ability4
    {
        if (player.GetComponent<KnightStats>().UnlockAB4 < 1 && player.GetComponent<KnightStats>().SkillPoints > 0) //max upgrades is 1
        {
            player.GetComponent<KnightStats>().UnlockAB4++;
            gameObject.GetComponent<Image>().color = Color.white;
            player.GetComponent<KnightStats>().SkillPoints--;
        }
    }
    //tooltip
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<AB4Description>().gameObject.GetComponent<Text>().text = "Learn Ability4, shock waves send rocks flying at opponents."; //waaa this was crazy to code
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<AB4Description>().gameObject.GetComponent<Text>().text = "";
    }
}
