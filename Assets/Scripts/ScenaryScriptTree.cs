using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenaryScriptTree : MonoBehaviour
{
    public const string LAYER_NAME = "Midground";
    public int sortingOrder = 1;
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
            sprite.sortingLayerName = "Foreground";
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
