using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallScript : MonoBehaviour
{

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
            GetComponentInChildren<SpriteRenderer>().sortingLayerName = "Midground";
        }
        else
        {
            GetComponentInChildren<SpriteRenderer>().sortingLayerName = "Foreground";
            //sprite.sortingLayerName = "Foreground";
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
