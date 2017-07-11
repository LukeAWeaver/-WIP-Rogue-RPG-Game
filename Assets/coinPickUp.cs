using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinPickUp : MonoBehaviour
{

    public SpriteRenderer sprite;
    public Sprite[] sprites;
    public int goldAmount;
    public AudioClip coinGrab;
    private AudioSource source;
    void Start()
    {
        goldAmount = 5;
        sprite.sprite = sprites[0];
        sprite = GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();

    }
    private void Update()
    {
        goldAmount = Random.Range(0 , 8);

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Knight_Player")
        {
            source.clip = coinGrab;
            source.Play();
            collision.gameObject.GetComponent<KnightStats>().gold = collision.gameObject.GetComponent<KnightStats>().gold + goldAmount;
            gameObject.SetActive(false);
        }


    }

}
