﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class energy : MonoBehaviour
{
    public GameObject player;
    private int toint;
    Text text;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<KnightStats>().gameObject;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        toint = (int)player.GetComponent<KnightStats>().energy;
        text.text ="Energy:  " + toint.ToString();
    }
}
