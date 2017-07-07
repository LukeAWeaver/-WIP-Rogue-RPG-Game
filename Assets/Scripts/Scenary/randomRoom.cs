using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomRoom : MonoBehaviour {
    public GameObject[] items;
    private int numberOfRooms;
    // Use this for initialization
    void Start () {
        Invoke("randomRooms",0f);
    }

    // Update is called once per frame
    void randomRooms()
    {
        int roomIndex = Random.Range(0, items.Length);
        var thisRoom = Instantiate(items[roomIndex], transform.position, transform.rotation);
    }
}
