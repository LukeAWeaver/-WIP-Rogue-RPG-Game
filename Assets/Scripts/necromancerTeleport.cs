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
    // Use this for initialization

    void Start ()
    {
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
            teleportStart.Play();
            StartCoroutine(Vanish());
            Debug.Log("tele");
            hpCheck=necromancerHP;

        }
	}
  IEnumerator Vanish()
  {
      Debug.Log("Coroutine");
      yield return new WaitForSeconds(1.5f);
      var necroPosition = gameObject.transform.position;

      temp=transform.position;
      temp.x = Random.Range(-8f, 8f);
      temp.z = Random.Range(-8f, 8f);
      necroPosition +=temp;

      gameObject.transform.position = necroPosition;
      Debug.Log("Wait");
      teleportEnd.Play();
      Debug.Log("Animation");
  }
}
