using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinrotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.transform.Rotate(new Vector3(90, 0, 0));
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0,1,0) * Time.deltaTime * 90, Space.World);
    }
}
