using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayerIcon : MonoBehaviour
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
        pos.x = pos.x - 8.5f;
        pos.y = pos.y + 3.8f;
        transform.SetPositionAndRotation((pos), transform.rotation);
    }
}
