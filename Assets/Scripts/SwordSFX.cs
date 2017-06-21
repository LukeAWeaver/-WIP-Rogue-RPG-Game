﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSFX : MonoBehaviour {
    AudioSource audio;
    public GameObject sword;
    public AudioClip swordCollide;
    
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "npcSword")
        {
            audio.PlayOneShot(swordCollide,.15f);
        }

    }
}
