using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerPotions : MonoBehaviour {
    public GameObject player;
    public int hpPot;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.T) && hpPot>0)
        {
            hpPot--;
            player.GetComponent<KnightStats>().health++;
        }
	}
}
