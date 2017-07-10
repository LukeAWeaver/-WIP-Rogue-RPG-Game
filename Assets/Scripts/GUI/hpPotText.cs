using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpPotText : MonoBehaviour {
    public PlayerPotions pots;
    Text text;
    // Use this for initialization
    void Start () {
		pots = FindObjectOfType<PlayerPotions>();
        text = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update () {
        text.text = "x" + PlayerPrefs.GetInt("hpPots").ToString();
    }
}
