using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenaryScript2 : MonoBehaviour
{
    public const string LAYER_NAME = "Foreground";
    public int sortingOrder = 0;
    private SpriteRenderer sprite;
    bool overlap;

    void Start()
    {
        overlap = false;
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (overlap)
        {
            sprite.sortingOrder = sortingOrder;
            sprite.sortingLayerName = LAYER_NAME;
        }
        else
        {
            sprite.sortingLayerName = "Midground";
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        overlap = true;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        overlap = false;

    }
}
