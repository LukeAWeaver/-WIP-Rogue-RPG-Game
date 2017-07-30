using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class necromancerTeleport : MonoBehaviour {

    private int necromancerHP;
    private int hpCheck;
    private Vector3 temp;
    private int counter;
    public GameObject teleport;
    // Use this for initialization

    void Start ()
    {
        teleport = Resources.Load("NecroTele") as GameObject;
        hpCheck=gameObject.GetComponent<MonsterInterface>().hp;
    }


    // Update is called once per frame
    void Update ()
    {
        if(counter%90 == 0)
        {
            hpCheck = gameObject.GetComponent<MonsterInterface>().hp; //every other frame it will update hpCheck (this means every other frame hp check might be larger than necro's hp
        }
        counter++;
        var necroPosition = gameObject.transform.position;
        var necroRotation = gameObject.transform.rotation;
        temp=transform.position;
        temp.x = Random.Range(-3f, 3f);
        temp.z = Random.Range(-3f, 3f);

        necroPosition +=temp;
        if(hpCheck==necromancerHP)
        {
            Debug.Log("this is spam");
        }
        else if(hpCheck > gameObject.GetComponent<MonsterInterface>().hp)
        {
            var tele = Instantiate(teleport, necroPosition, necroRotation);
            Debug.Log("tele");
            hpCheck=necromancerHP;
            gameObject.transform.position = necroPosition;
        }
	}
}
