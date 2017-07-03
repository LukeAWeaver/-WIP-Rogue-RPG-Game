using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogScript : MonoBehaviour {
    Animator actions;
    public AudioClip bark;
    public AudioClip whimper;
    private AudioSource source;
    public int hp;
    public float velocity;
    private float sniff;
    public float damage;
    public bool insight;
    // Use this for initialization
    void Start () {
        hp = 4;
        velocity = .5f;
        damage = 2;
        source = GetComponent<AudioSource>();
        actions = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        sniff = Random.Range(-5f, 5f);
        if(hp==0)
        {
            this.gameObject.SetActive(false);
        }
        if(insight)
        {

        }
        if (sniff > -.01f && sniff < .01f)
        {
            actions.Play("sniffing");
            actions.StopPlayback();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "PlayerWoodenSword")
        {
            hp--;
            source.clip = whimper;
            source.Play();
        }
        if (collision.gameObject.name == "Knight_Player")
        {

            actions.SetInteger("state", 1);
            if (collision.gameObject.GetComponent<KnightStats>().isRecovering)
            {

            }
            else
            {
                CombatTextManager.Instance.CreateText(collision.transform.position);
                collision.gameObject.GetComponent<KnightStats>().health--; //im a genius
                collision.gameObject.GetComponent<KnightStats>().isRecovering = true; //im a genius
                source.clip = bark;
                source.Play();
            }

            collision.gameObject.GetComponent<KnightStats>().tempHP = collision.gameObject.GetComponent<KnightStats>().health;
        }
    }
}
