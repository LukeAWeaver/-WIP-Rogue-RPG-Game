using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class str : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject player;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<KnightStats>().gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<KnightStats>().UnlockAB1 == 1)
        {
            GetComponent<Image>().color = Color.white;
        }
        else
        {
            GetComponent<Image>().color = new Color32(128, 113, 113, 255);
        }
    }
    //tooltip
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<strDescription>().gameObject.GetComponent<Text>().text = "Strength will help you hit harder. (Upgradable at the attribution trainer)"; //waaa this was crazy to code
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<strDescription>().gameObject.GetComponent<Text>().text = "";
    }
}
