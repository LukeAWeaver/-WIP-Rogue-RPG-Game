using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hp : MonoBehaviour
{
    public Sprite[] hpLeft;
    public GameObject player;
    //public SpriteRenderer currentHp;
    public KnightStats stats;
	// Use this for initialization
	void Start ()
    {
        player = FindObjectOfType<KnightStats>().gameObject;
        stats = player.GetComponent<KnightStats>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.GetComponent<Image>().sprite = hpLeft[stats.health];

    }
}
