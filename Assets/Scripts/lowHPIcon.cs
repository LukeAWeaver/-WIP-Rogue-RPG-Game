using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lowHPIcon : MonoBehaviour {
    public Sprite[] states;
    public GameObject player;
    public SpriteRenderer currentState;
    public KnightStats stats;
    // Use this for initialization
    void Start () {
        stats = player.GetComponent<KnightStats>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (stats.health < 4)
        {
            currentState.sprite = states[1];
        }
        else
        {
            currentState.sprite = states[0];
        }
    }
}
