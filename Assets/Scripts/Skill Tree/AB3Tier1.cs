using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AB3Tier1 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button sp;
    private GameObject player;
    public GameObject Ability3;

    // Use this for initialization
    void Start()
    {
        Ability3 = Resources.Load("Ability3") as GameObject;
        player = FindObjectOfType<KnightStats>().gameObject;
        Button btn = sp.GetComponent<Button>();
        btn.onClick.AddListener(A3ATKPWR);

    }
    private void Update()
    {
        if (player.GetComponent<KnightStats>().UnlockAB3 == 1 && Ability3.GetComponent<ability3Script>().AB3dmg > 0) //atleast 1 point in current skill
        {
            GetComponent<Image>().color = Color.white;
        }
        else if (player.GetComponent<KnightStats>().UnlockAB3 == 1) //previous skill maxed out
        {
            GetComponent<Image>().color = new Color32(128, 113, 113, 255);
        }
    }
    void A3ATKPWR() //ability3 tier 1
    {
        if (Ability3.GetComponent<ability3Script>().AB3dmg < 5 && player.GetComponent<KnightStats>().SkillPoints > 0 && player.GetComponent<KnightStats>().UnlockAB3 == 1) //max upgrades is 5
        {
            Ability3.GetComponent<ability3Script>().AB3dmg++;
            player.GetComponent<KnightStats>().SkillPoints--;
        }
    }
    //tooltip
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<AB3Tier1Description1>().gameObject.GetComponent<Text>().text = "Increases Ability 3 Damage."; //waaa this was crazy to code
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<AB3Tier1Description1>().gameObject.GetComponent<Text>().text = "";
    }
}
