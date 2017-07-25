using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SKIdentifier : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update () {
        if(Time.frameCount<10)
        gameObject.SetActive(false);

    }
}
