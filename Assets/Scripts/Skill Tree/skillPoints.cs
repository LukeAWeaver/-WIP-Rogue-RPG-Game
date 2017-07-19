using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillPoints : MonoBehaviour {
    public GameObject player;
    Text text;
    // Use this for initialization
    void Start () {
        player = FindObjectOfType<KnightStats>().gameObject;
        text = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        text.text = "SKILL POINTS: " + player.GetComponent<KnightStats>().SkillPoints.ToString();
    }
}
