using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpFollowNpc : MonoBehaviour
{
    public GameObject player;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var pos = player.transform.position;
        pos.y = pos.y + .75f;
        pos.x = pos.x + .75f;
        transform.SetPositionAndRotation((pos), transform.rotation);
    }
}
