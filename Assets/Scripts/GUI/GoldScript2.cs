using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldScript2 : MonoBehaviour
{
    public Sprite[] gold;
    public GameObject player;
    //public SpriteRenderer currentGold;
    public KnightStats stats;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<KnightStats>().gameObject;
        stats = player.GetComponent<KnightStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(stats.gold == 0)
        {
            gameObject.GetComponent<Image>().sprite = gold[0];
        }
        else if (stats.gold < 3)
        {
            gameObject.GetComponent<Image>().sprite = gold[1];

        }
        else if (stats.gold < 6)
        {
            gameObject.GetComponent<Image>().sprite = gold[2];

        }
        else if (stats.gold < 21)
        {
            gameObject.GetComponent<Image>().sprite = gold[3];
        }
        else if (stats.gold <26)
        {
            gameObject.GetComponent<Image>().sprite = gold[4];

        }
        else if(stats.gold >=26)
        {
            gameObject.GetComponent<Image>().sprite = gold[5];
        }

    }
}
