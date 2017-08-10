using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class necromancerTeleport : MonoBehaviour {
    public GameObject necromancer;
    private int necromancerHP;
    private int hpCheck;
    private Vector3 temp;
    private Vector3 temp1;
    private int counter;
    public ParticleSystem teleportStart;
    public ParticleSystem teleportEnd;
    private float radius = 1f;
    // Use this for initialization

    void Start ()
    {
        necromancer = FindObjectOfType<SummonSkeleton>().gameObject;
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

        if(hpCheck==necromancerHP)
        {
            Debug.Log("this is spam");
        }
        else if(hpCheck > gameObject.GetComponent<MonsterInterface>().hp)
        {
            var teleportS = Instantiate(teleportStart, new Vector3(necromancer.transform.position.x, necromancer.transform.position.y - .5f, necromancer.transform.position.z), Quaternion.Euler(-90f,0f,0f));
            teleportS.Play();
            StartCoroutine(Vanish());
            Debug.Log("tele");
            hpCheck=necromancerHP;

        }
	}
  IEnumerator Vanish()
  {
    Debug.Log("Coroutine");
    var necroPosition = gameObject.transform.position;

    temp=transform.position;
    temp.x = Random.Range(-8f, 8f);
    temp.z = Random.Range(-8f, 8f);

    temp1=necroPosition+temp;

    if(Physics.CheckSphere (temp1, radius))
    {
            StartCoroutine(Vanish());
        }
    else
        {
        var teleportE = Instantiate(teleportEnd, (new Vector3(necromancer.transform.position.x, necromancer.transform.position.y - .5f, necromancer.transform.position.z) + temp), Quaternion.Euler(-90f, 0f, 0f));
        necroPosition +=temp;
        teleportE.Play();
        yield return new WaitForSeconds(.5f);
        gameObject.transform.position = necroPosition;
        }
    }
}
