using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class necromancerTeleport : MonoBehaviour {

    public GameObject necromancer;
    private int necromancerHP;
    private int hpCheck;
    private Vector3 temp;

    // Use this for initialization
    void Start ()
    {
        hpCheck=gameObject.GetComponent<MonsterInterface>().hp;
        necromancerHP=gameObject.GetComponent<MonsterInterface>().hp;
    }

    // Update is called once per frame
    void Update ()
    {
        var necroPosition = necromancer.transform.position;

        temp=transform.position;
        temp.x = Random.Range(-3f, 3f);
        temp.z = Random.Range(-3f, 3f);

        necromancerHP=gameObject.GetComponent<MonsterInterface>().hp;

        necroPosition +=temp;
        if(hpCheck==necromancerHP)
        {

        }
        else if(hpCheck < necromancerHP)
        {
            hpCheck=necromancerHP;
            gameObject.transform.position = necroPosition;
        }
	}
}
