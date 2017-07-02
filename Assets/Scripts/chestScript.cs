using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestScript : MonoBehaviour
{

    public SpriteRenderer sprite;
    public Sprite[] sprites;
    public int goldAmount;
    public AudioClip chestOpen;
    public AudioClip coinGrab;
    private AudioSource source;
    void Start()
    {
        goldAmount = 2;
        sprite.sprite = sprites[0];
        sprite = GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();

    }
    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="Sword" && sprite.sprite ==sprites[0])
        {
            source.clip = chestOpen;
            source.Play();
            sprite.sprite = sprites[1];
        }
        if(collision.gameObject.name =="Knight_Player" && sprite.sprite ==sprites[1])
        {
                 source.clip = coinGrab;
                 source.Play();
                 sprite.sprite = sprites[2];
                 collision.gameObject.GetComponent<KnightStats>().gold = collision.gameObject.GetComponent<KnightStats>().gold + goldAmount;
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {


    }
}
