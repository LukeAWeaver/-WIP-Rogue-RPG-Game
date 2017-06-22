using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMonsterSpawner : MonoBehaviour {
    public GameObject[] RandomMonsters;
    public GameObject Knife;
    public float spawnDelay = .1f;
    public float spawnTime = 1f;
    // Use this for initialization
    void Start () {
        InvokeRepeating("SpawnRandom", spawnDelay, spawnTime);
    }

    public void SpawnRandom()
    {
        int enemyIndex = Random.Range(0, RandomMonsters.Length);
        var ThisEnemy = Instantiate(RandomMonsters[enemyIndex], transform.position, transform.rotation);
        ThisEnemy.SetActive(true);
        if(ThisEnemy.gameObject.name == "Goblin_Small(Clone)")
        {
            Instantiate(Knife);
            this.Knife.GetComponent<weaponFollowNPC>().npc = ThisEnemy;
            this.Knife.GetComponent<weaponFollowNPC>().CheckFlip = ThisEnemy.GetComponent<AI>();
            this.Knife.SetActive(true);
        }
        if (ThisEnemy.gameObject.name == "Goblin_Big(Clone)")
        {
            Instantiate(Knife);
            this.Knife.GetComponent<weaponFollowNPC>().npc = ThisEnemy;
            this.Knife.GetComponent<weaponFollowNPC>().CheckFlip = ThisEnemy.GetComponent<AI>();
            this.Knife.SetActive(true);
        }

    }
    // Update is called once per frame
    void Update () {
		
	}
}
