using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_ClubSwing : MonoBehaviour
{
    Animator swing;
    public AudioClip thud;
    public GameObject thisGoblin;
    private AudioSource source;
    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
        swing = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    private void OnTriggerEnter(Collider collision)
    {
        int changeInHP = PlayerPrefs.GetInt("currentHP") - 1;
        if (collision.gameObject.GetComponent<KnightStats>() != null && !collision.gameObject.GetComponent<KnightStats>().isRecovering)
        {
            collision.GetComponent<Rigidbody>().velocity += new Vector3(0f, 2f, 0f);
            if (thisGoblin.GetComponent<MonsterInterface>().isFlippingLeft)
            {
                collision.GetComponent<Rigidbody>().velocity += new Vector3(-8f, 0f, 0f);
            }
            if (thisGoblin.GetComponent<MonsterInterface>().isFlippingRight)
            {
                collision.GetComponent<Rigidbody>().velocity += new Vector3(8f, 0f, 0f);
            }
            CombatTextManager.Instance.CreateText(collision.transform.position);
            PlayerPrefs.SetInt("currentHP", changeInHP);
            collision.gameObject.GetComponent<KnightStats>().isRecovering = true;
            source.clip = thud;
            source.Play();

        }
    }
    private void OnTriggerExit(Collider other)
    {
        swing.SetBool("inProx", false);
    }
}
