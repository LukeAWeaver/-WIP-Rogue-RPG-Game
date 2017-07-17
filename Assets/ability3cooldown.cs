using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ability3cooldown : MonoBehaviour {
    Text text;
    public GameObject ability3Icon;
    private float cd;
    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update () {
        if (ability3Icon.GetComponent<Image>().color != Color.white && Time.deltaTime %.1 == 0)
        {
            cd = cd - .05f;
            text.text = Math.Round(cd,2).ToString();
        }
        else
        {
            cd = 5f;
            text.text = "";
        }
    }
}
