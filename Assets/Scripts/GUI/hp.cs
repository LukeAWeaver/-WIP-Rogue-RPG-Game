using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp : MonoBehaviour
{
    public Sprite[] hpLeft;
    public GameObject player;
    public SpriteRenderer currentHp;
    public KnightStats stats;
	// Use this for initialization
	void Start ()
    {
        stats = player.GetComponent<KnightStats>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentHp.sprite = hpLeft[stats.health];

    }
}
