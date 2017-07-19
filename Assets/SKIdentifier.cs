using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SKIdentifier : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.frameCount<60)
        gameObject.SetActive(false);

    }
}
