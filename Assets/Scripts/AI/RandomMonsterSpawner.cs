using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomMonsterSpawner : MonoBehaviour {
    private GameObject[] RandomMonsters;
    private GameObject GoblinMelee;
    private GameObject GoblinArcher;
    private GameObject Dog;

    public float spawnDelay = .1f;
    public float spawnTime = 1f;
    public int limit;
    public int enemyIndex;
    // Use this for initialization
    void Start () {
        RandomMonsters = new GameObject[3];
        GoblinMelee = Resources.Load("GoblinClub") as GameObject;
        RandomMonsters[0] = GoblinMelee;
        GoblinArcher = Resources.Load("GoblinBow") as GameObject;
        RandomMonsters[1] = GoblinArcher;
        Dog = Resources.Load("dog") as GameObject;
        RandomMonsters[2] = Dog;



        limit = 0;
        InvokeRepeating("SpawnRandom", spawnDelay, spawnTime);
    }
    public void SpawnRandom()
    {
        if (limit < 3)
        {
            if(SceneManager.GetActiveScene().name == "ForestBiome")
            {
                enemyIndex = Random.Range(0, 2);
            }
            else
                enemyIndex = Random.Range(0, RandomMonsters.Length);
            var ThisEnemy = Instantiate(RandomMonsters[enemyIndex], transform.position, transform.rotation);
            if(ThisEnemy.gameObject.name == "dog(Clone)")
            {
                Debug.Log("test");
                //ThisEnemy.gameObject.GetComponent<Transform>().rotation = new Quaternion(0f, 0f, 0f, 0f);
            }
            ThisEnemy.SetActive(true);
            Destroy(this.gameObject);
            limit++;
        }
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
