using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonSkeleton : MonoBehaviour {
    public bool inSight;
    private GameObject player;
    private GameObject skele;
    public MonsterInterface ThisNPCStats;
    public float range;
    private bool onCD;
    private int rng;
    // Use this for initialization
    void Start () {
        gameObject.GetComponent<MonsterInterface>().hp = 12;
        player = FindObjectOfType<KnightStats>().gameObject;
        onCD = false;
    }

    // Update is called once per frame
    void Update ()
    {
        var target = player.transform.position;
        var gp = ThisNPCStats.transform.position;
        ThisNPCStats = gameObject.GetComponent<MonsterInterface>();

        range = Mathf.Sqrt((target.x - gp.x) * (target.x - gp.x) + (target.y - gp.y) * (target.y - gp.y));
        if (range < 10)
        {
            inSight = true;
        }
        else
        {
            inSight = false;
        }
        if (inSight && onCD == false)
        {
            StartCoroutine(SummonSkeleOnCD());
            rng = Random.Range(0, 2);
            if (rng == 1)
            {
                skele = Resources.Load("Skeleton") as GameObject;
            }
            else if (rng == 2)
            {
                skele = Resources.Load("Skeleton2") as GameObject;
            }
            Instantiate(skele, new Vector3(transform.position.x + Random.Range(-1f, 1f), transform.position.y + .5f, transform.position.z + Random.Range(-1f, 1f)), transform.rotation);
        }
	}
    IEnumerator SummonSkeleOnCD()
    {
        onCD = true;
        yield return new WaitForSeconds(.8f);
        onCD = false;
    }
}
