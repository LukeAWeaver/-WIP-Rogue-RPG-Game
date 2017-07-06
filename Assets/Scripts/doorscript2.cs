using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorscript2 : MonoBehaviour {
    public Sprite[] sprites;
    public SpriteRenderer sprite;
    public AudioClip doorOpen;
    public AudioClip doorClose;
    private AudioSource source;
    // Use this for initialization
    void Start () {
        sprite.sprite = sprites[0];
        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update () {
		
	}
    private void OnTriggerEnter(Collider collision)
    {
        source.clip = doorOpen;
        source.Play();
        sprite.sprite = sprites[1];
    }
    private void OnTriggerExit(Collider collision)
    {
        source.clip = doorClose;
        source.Play();
        sprite.sprite = sprites[0];
    }
}
