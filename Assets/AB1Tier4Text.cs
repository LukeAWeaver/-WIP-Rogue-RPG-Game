using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AB1Tier4Text : MonoBehaviour
{
    Text text;
    private GameObject thisSkill;
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<KnightStats>().gameObject;
        text = GetComponent<Text>();
        thisSkill = FindObjectOfType<AB1Tier4>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = (player.GetComponentInChildren<AB1DOT>().ultimateEnabled).ToString() + "/1";
    }
}
