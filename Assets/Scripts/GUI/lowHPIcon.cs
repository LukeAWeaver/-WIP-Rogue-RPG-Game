using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lowHPIcon : MonoBehaviour {
    public Sprite[] states;
    public GameObject player;
   // public SpriteRenderer currentState;
    public KnightStats stats;
    // Use this for initialization
    void Start () {
        player = FindObjectOfType<KnightStats>().gameObject;
        stats = player.GetComponent<KnightStats>();
    }

    // Update is called once per frame
    void Update ()
    {

        if (stats.health < 5)
        {
            gameObject.GetComponent<Image>().sprite = states[1];
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = states[0];
        }
    }
}
