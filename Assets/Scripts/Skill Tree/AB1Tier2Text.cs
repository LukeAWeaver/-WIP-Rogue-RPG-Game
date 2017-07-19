using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AB1Tier2Text : MonoBehaviour
{
    Text text;
    private GameObject thisSkill;
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<KnightStats>().gameObject;
        text = GetComponent<Text>();
        thisSkill = FindObjectOfType<AB1Tier2>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = ((int)(player.GetComponent<KnightStats>().SPBonusMS*500)).ToString() + "/5";
    }
}
