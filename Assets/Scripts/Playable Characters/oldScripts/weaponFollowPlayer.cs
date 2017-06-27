using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponFollowPlayer : MonoBehaviour
{
    public Player1Controls CheckFlip;
    public GameObject player;
    public string flip;
    void Start ()
    {

    }

    void Update ()
    {
        if(!player.activeInHierarchy)
        {
            this.gameObject.SetActive(false);
        }

        var pos = player.transform.position;
        pos.y = pos.y -.2f;
        flip = CheckFlip.flip;
        if (flip == "left")
        {
            transform.rotation = Quaternion.Euler(0, 0, 21); ;
            pos.x = pos.x - .5f;
            transform.SetPositionAndRotation((pos), transform.rotation);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, -21); ;
            pos.x = pos.x + .5f;
            transform.SetPositionAndRotation((pos), transform.rotation);
        }



    }

}
