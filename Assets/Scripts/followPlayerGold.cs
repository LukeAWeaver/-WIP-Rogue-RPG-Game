using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayerGold : MonoBehaviour
{
    public GameObject camera;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var pos = camera.transform.position;
        pos.x = pos.x + 7.6f;
        pos.y = pos.y + 4.6f;
        pos.z = pos.z + 1f;
        transform.SetPositionAndRotation((pos), transform.rotation);
    }
}
