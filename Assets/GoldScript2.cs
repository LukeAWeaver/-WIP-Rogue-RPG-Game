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
        currentGold.sprite = gold[2];

    }
}
