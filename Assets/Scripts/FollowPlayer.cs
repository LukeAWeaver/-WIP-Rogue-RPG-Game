using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var pos = player.transform.position;
        pos.z = pos.z -25;
        transform.SetPositionAndRotation((pos), transform.rotation);

	}
}
