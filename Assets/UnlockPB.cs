using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockPB : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<KnightStats>() !=null)
        {
            PlayerPrefs.SetInt("PBUnlocked", 1);
        }
    }
}
