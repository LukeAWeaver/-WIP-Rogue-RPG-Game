using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponFollowNPC : MonoBehaviour
{
    public AI CheckFlip;
    public GameObject npc;
    public string direction;
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
        Vector3 temp = Input.mousePosition;
        temp.x = 1f;
        this.transform.position = Camera.main.ScreenToWorldPoint(temp);
        direction = CheckFlip.flip;
        if (direction== "right")
        {
            transform.rotation = Quaternion.Euler(0, 0, 21);
            pos.x = pos.x - 15;
            transform.SetPositionAndRotation((pos), transform.rotation);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, -21);
            pos.x = pos.x + 15;
            transform.SetPositionAndRotation((pos), transform.rotation);
        }



    }
}
