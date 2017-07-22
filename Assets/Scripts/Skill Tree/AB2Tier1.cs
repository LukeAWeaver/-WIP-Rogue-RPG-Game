using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AB2Tier1 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button sp;
    private GameObject player;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<KnightStats>().gameObject;
        Button btn = sp.GetComponent<Button>();
        btn.onClick.AddListener(A2ATKPWR);

    }
    private void Update()
    {
        if (player.GetComponent<KnightStats>().UnlockAB2 == 1 && player.GetComponent<KnightStats>().AB2BonusATK > 0)
        {
            GetComponent<Image>().color = Color.white;
        }
        else if (player.GetComponent<KnightStats>().UnlockAB2 == 1)
        {
            GetComponent<Image>().color = new Color32(128, 113, 113, 255);
        }
    }

    void A2ATKPWR() //ability2 tier 1
    {
        if (player.GetComponent<KnightStats>().AB2BonusATK < 5 && player.GetComponent<KnightStats>().SkillPoints > 0 && player.GetComponent<KnightStats>().UnlockAB2 == 1) //max upgrades is 5
        {
            player.GetComponent<KnightStats>().AB2BonusATK++;
            player.GetComponent<KnightStats>().SkillPoints--;
        }
    }
    //tooltip
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<AB2Tier1Description>().gameObject.GetComponent<Text>().text = "Increases Ability 2 Damage."; 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<AB2Tier1Description>().gameObject.GetComponent<Text>().text = "";
    }
}
