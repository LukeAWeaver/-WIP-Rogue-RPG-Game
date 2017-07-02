using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armorCling : MonoBehaviour {
    public AudioClip cling;
    private AudioSource source;
    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "PlayerWoodenSword")
        {
            source.clip = cling;
            source.Play();
        }
    }
}
