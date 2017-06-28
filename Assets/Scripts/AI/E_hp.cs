using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_hp : MonoBehaviour
{
    public Sprite[] hpLeft;
    public GameObject player;
    public SpriteRenderer currentHp;
    public goblinInterface stats;
    // Use this for initialization
    void Start()
    {
        stats = player.GetComponent<goblinInterface>();
        //currentHp.sprite = hpLeft[12];
    }

    // Update is called once per frame
    void Update()
    {
        if(stats.hp >-1)
        currentHp.sprite = hpLeft[stats.hp];
        if(stats.hp<1)
        {
            this.gameObject.SetActive(false);
        }
    }
}
