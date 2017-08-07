using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStageOfBiome : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("CurrentFloor") == 0 || PlayerPrefs.GetInt("CurrentFloor") == 3 || PlayerPrefs.GetInt("CurrentFloor") == 6)
            {
            gameObject.SetActive(true);
            }
        else
        {
            gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
