using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldScript2 : MonoBehaviour
{
    public Sprite[] gold;
    public GameObject player;
    public SpriteRenderer currentGold;
    public KnightStats stats;
    // Use this for initialization
    void Start()
    {
        stats = player.GetComponent<KnightStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(stats.gold == 0)
        {
            currentGold.sprite = gold[0];
        }
        else if (stats.gold < 3)
        {
            currentGold.sprite = gold[1];

        }
        else if (stats.gold < 6)
        {
            currentGold.sprite = gold[2];

        }
        else if (stats.gold < 21)
        {
            currentGold.sprite = gold[3];
        }
        else if (stats.gold <26)
        {
            currentGold.sprite = gold[4];

        }
        else if(stats.gold < 35)
        {
            currentGold.sprite = gold[5];
        }

    }
}
