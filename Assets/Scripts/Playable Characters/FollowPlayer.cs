using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
	void Start ()
    {
		
	}
	
	void Update ()
    {
        var pos = player.transform.position;
        pos.z = pos.z -25;
        transform.SetPositionAndRotation((pos), transform.rotation);

	}
}
