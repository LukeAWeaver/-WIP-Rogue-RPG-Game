using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomRoom : MonoBehaviour {
    public GameObject[] items;
    private int numberOfRooms;
    // Use this for initialization
    void Start () {
        items = new GameObject[3];
        items[0] = Resources.Load("DungeonTerrain1") as GameObject;
        items[1] = Resources.Load("DungeonTerrain2") as GameObject;
        items[2] = Resources.Load("DungeonTerrain3") as GameObject;


        Invoke("randomRooms",0f);
    }

    // Update is called once per frame
    void randomRooms()
    {
        int roomIndex = Random.Range(0, items.Length);
        var thisRoom = Instantiate(items[roomIndex], transform.position, transform.rotation);
    }
}
