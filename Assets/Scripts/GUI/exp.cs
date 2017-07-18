using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exp : MonoBehaviour {
    public GameObject player;
    Text text;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<KnightStats>().gameObject;
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "EXP: " + player.GetComponent<KnightStats>().exp.ToString() + "/" + player.GetComponent<KnightStats>().requiredExp.ToString();
	}
}
