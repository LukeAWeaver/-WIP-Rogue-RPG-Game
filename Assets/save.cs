using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("currentHP", 12);
        PlayerPrefs.SetFloat("atkSpeed", 1f);
        PlayerPrefs.SetInt("hpPots", 0);
    }

    // Update is called once per frame
    void Update () {
	}
}
