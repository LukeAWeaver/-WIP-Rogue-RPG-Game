using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomTiles : MonoBehaviour {
    public SpriteRenderer sprite;
    public Sprite[] sprites;
    private int numberOfTiles;
    private int rotation;
    private int rng;
    // Use this for initialization
    void Start () {
        Invoke("randomTile", 0f);

    }

    // Update is called once per frame
    void randomTile()
    {
        int tileIndex = Random.Range(0, sprites.Length);
        rng = Random.Range(1, 4);
        if(rng == 1)
            rotation = 0;
        if (rng == 2)
            rotation = 90;
        if (rng == 3)
            rotation = 180;
        if (rng == 4)
            rotation = 270;
        sprite.sprite = sprites[tileIndex];
        sprite.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, rotation));
    }
}
