using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    // Use this for initialization
    public int CF;
    public GameObject BOSS;
    private GameObject player;

    void Start()
    {
        if(PlayerPrefs.GetInt("CurrentFloor") == 2)
        {
            BOSS = Resources.Load("Necromancer") as GameObject;
            var boss = Instantiate(BOSS);
            boss.GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
            boss.GetComponent<Transform>().position = new Vector3(108f, 1.64f, -7f);
        }
        player = FindObjectOfType<KnightStats>().gameObject;
    }

        // Update is called once per frame
        void Update ()
    {
        if(player.GetComponent<KnightStats>().health<=0)
        {
            PlayerPrefs.SetInt("CurrentFloor", 0);
        }

        CF = PlayerPrefs.GetInt("CurrentFloor");
        Debug.Log(CF);

    }
    private void OnTriggerEnter(Collider other)
    {
        if(SceneManager.GetActiveScene().name == "DungeonBiome")
        {
            CF++;
            PlayerPrefs.SetInt("CurrentFloor", CF);

        }
        if (CF<3) // 0,1,2
        {
            SceneManager.LoadScene("DungeonBiome");
        }
        else if(CF<6) // 3,4,5
        {
            SceneManager.LoadScene("Floor1");

        }
    }
}
