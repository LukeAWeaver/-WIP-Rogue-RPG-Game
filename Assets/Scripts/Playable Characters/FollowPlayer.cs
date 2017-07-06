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
        pos.y = pos.y + 2f;
        pos.z = pos.z - 7f;
        transform.SetPositionAndRotation((pos), transform.rotation);

	}
}
