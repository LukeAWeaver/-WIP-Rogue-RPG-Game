using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogScript : MonoBehaviour {
    Animator actions;
    public AudioClip bark;
    public AudioClip whimper;
    private AudioSource source;
    public MonsterInterface Thisdog;
    public GameObject player;

    private float sniff;
    public float damage;
    public bool insight;
    public float range;
    public string flip;
    private float x;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<KnightStats>().gameObject;
        Thisdog.rotationSpeed = 7f;
        Thisdog.hp = 6;
        Thisdog.ms= .06f;
        damage = 2;
        source = GetComponent<AudioSource>();
        actions = GetComponent<Animator>();
        x = Mathf.Abs(transform.localScale.x);

    }

    // Update is called once per frame
    void Update () {
        sniff = Random.Range(-5f, 5f);
        if(Thisdog.hp<=0)
        {
            this.gameObject.SetActive(false);
            player.GetComponent<KnightStats>().exp = player.GetComponent<KnightStats>().exp + 2;
        }
        var target = player.transform.position;
        var dogPosition = Thisdog.transform.position;
        range = Mathf.Sqrt((target.x - dogPosition.x) * (target.x - dogPosition.x) + (target.z - dogPosition.z) * (target.z - dogPosition.z));
        if (range <7)
        {
            insight = true;
        }
        if(insight)
        {
            actions.SetInteger("state", 2);
            if (transform.position.x > target.x)
            {
                Thisdog.isFlippingLeft = false;
                Thisdog.isFlippingRight = true;
                transform.Translate(-Thisdog.ms, 0f, 0f);
            }
            else if (transform.position.x < target.x)
            {
                Thisdog.isFlippingLeft = true;
                Thisdog.isFlippingRight = false;

                transform.Translate(Thisdog.ms, 0f, 0f);
            }
            if (transform.position.z > target.z)
            {
                transform.Translate(0f, 0f, -Thisdog.ms);
            }
            else
            {
                transform.Translate(0f, 0f, Thisdog.ms);
            }
        }
        else if (sniff > -.01f && sniff < .01f)
        {
            actions.Play("sniffing");
            actions.StopPlayback();
            actions.SetInteger("state", 2);
        }
        else
        {
            actions.SetInteger("state", 0);
        }
        Thisdog.CheckFlipping();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PlayerWoodenSword")
        {
            source.clip = whimper;
            source.Play();
        }
        if (collision.gameObject.name == "Knight_Player")
        {
            int changeInHP = PlayerPrefs.GetInt("currentHP") - 1;
            // actions.SetInteger("state", 1);
            if (collision.gameObject.GetComponent<KnightStats>() != null && !collision.gameObject.GetComponent<KnightStats>().isRecovering)
            {

            }
            else
            {
                CombatTextManager.Instance.CreateText(collision.transform.position);
                PlayerPrefs.SetInt("currentHP", changeInHP);
                collision.gameObject.GetComponent<KnightStats>().isRecovering = true; 
                source.clip = bark;
                source.Play();
            }

            collision.gameObject.GetComponent<KnightStats>().tempHP = collision.gameObject.GetComponent<KnightStats>().health;
        }
    }
}
