using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class randomRoom : MonoBehaviour {
    public GameObject[] items;
    // Use this for initialization
    void Start () {
        items = new GameObject[3];
        
        if (SceneManager.GetActiveScene().name == "DungeonBiome")
        {
            items[0] = Resources.Load("DungeonTerrain1") as GameObject;
            items[1] = Resources.Load("DungeonTerrain2") as GameObject;
            items[2] = Resources.Load("DungeonTerrain3") as GameObject;
        }
        else if (SceneManager.GetActiveScene().name == "ForestBiome")
        {
            items[0] = Resources.Load("GrassTerrain1") as GameObject;
            items[1] = Resources.Load("GrassTerrain2") as GameObject;
            items[2] = Resources.Load("GrassTerrain1") as GameObject;
        }
        else
        {
            items[0] = null;
            items[1] = null;
            items[2] = null;
        }


        Invoke("randomRooms",0f);
    }

    // Update is called once per frame
    void randomRooms()
    {
        int roomIndex = Random.Range(0, items.Length);
        var thisRoom = Instantiate(items[roomIndex], transform.position, transform.rotation);
    }
}
