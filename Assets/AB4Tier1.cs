using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AB4Tier1 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button sp;
    private GameObject player;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<KnightStats>().gameObject;
        Button btn = sp.GetComponent<Button>();
        btn.onClick.AddListener(A4ATKPWR);

    }
    private void Update()
    {
        if (player.GetComponent<KnightStats>().UnlockAB4 == 1 && player.GetComponent<KnightStats>().AB4BonusATK > 0) //atleast 1 point in current skill
        {
            GetComponent<Image>().color = Color.white;
        }
        else if (player.GetComponent<KnightStats>().UnlockAB4 == 1) //previous skill maxed out
        {
            GetComponent<Image>().color = new Color32(128, 113, 113, 255);
        }
    }
    void A4ATKPWR() //ability4 tier 1
    {
        if (player.GetComponent<KnightStats>().AB4BonusATK < 5 && player.GetComponent<KnightStats>().SkillPoints > 0 && player.GetComponent<KnightStats>().UnlockAB4 == 1) //max upgrades is 5
        {
            player.GetComponent<KnightStats>().AB4BonusATK++;
            player.GetComponent<KnightStats>().SkillPoints--;
        }
    }
    //tooltip
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<AB4Tier1Description>().gameObject.GetComponent<Text>().text = "Increases Ability 4 Damage."; //waaa this was crazy to code
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<AB4Tier1Description>().gameObject.GetComponent<Text>().text = "";
    }
}
