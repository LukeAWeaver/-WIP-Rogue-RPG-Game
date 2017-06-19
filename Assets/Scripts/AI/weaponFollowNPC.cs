using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponFollowNPC : MonoBehaviour
{
    public AI CheckFlip;
    public GameObject npc;
    public string flip;
    void Start ()
    {

    }

    void Update ()
    {
        if (!npc.activeInHierarchy)
        {
            this.gameObject.SetActive(false);
        }


        var pos = npc.transform.position;
        pos.y = pos.y + 15;
        flip = CheckFlip.flip;
        if (flip == "right")
        {
            transform.rotation = Quaternion.Euler(0, 0, 21); ;
            pos.x = pos.x - 15;
            transform.SetPositionAndRotation((pos), transform.rotation);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, -21); ;
            pos.x = pos.x + 15;
            transform.SetPositionAndRotation((pos), transform.rotation);
        }



    }
}
