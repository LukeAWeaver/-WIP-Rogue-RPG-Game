using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMonsterSpawner : MonoBehaviour {
    public GameObject[] RandomMonsters;
    public GameObject hp;
    public float spawnDelay = .1f;
    public float spawnTime = 1f;
    public int limit;
    // Use this for initialization
    void Start () {
        limit = 0;
        InvokeRepeating("SpawnRandom", spawnDelay, spawnTime);
    }
    public void SpawnRandom()
    {

            int enemyIndex = Random.Range(0, RandomMonsters.Length);
            var ThisEnemy = Instantiate(RandomMonsters[enemyIndex], transform.position, transform.rotation);
            ThisEnemy.SetActive(true);
            limit++;
        /*
        if(ThisEnemy.gameObject.name == "goblinClub(Clone)")
        {
            Instantiate(hp);
            this.hp.GetComponent<E_hp>().player = ThisEnemy;
            this.hp.GetComponent<E_hp>().stats = ThisEnemy.GetComponent<goblinInterface>();
            this.hp.SetActive(true);
        }*/

    }
    // Update is called once per frame
    void Update () {
		
	}
}
