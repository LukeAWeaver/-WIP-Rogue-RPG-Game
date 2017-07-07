using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowKnightSwordSwing : MonoBehaviour
{
    Animator swing;
    public AudioClip swinging;
    public AudioClip ability3;
    public AudioClip hittingWood;
    public GameObject ab3;
    public GameObject player;
    private AudioSource source;
    public ShadowKnightAI SK;
    public int test;

    // Use this for initialization
    void Start()
    {
        SK = gameObject.GetComponentInParent<ShadowKnightAI>();
        swing = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        test = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (SK.inSight)
        {
            test++;
            if(test ==1)
            {
                var swordSwing1 = Instantiate(ab3, transform.position, transform.rotation);
            }
        }
   
    }
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.GetComponent<KnightStats>() != null)
        {
            CombatTextManager.Instance.CreateText(collision.transform.position);

            collision.gameObject.GetComponent<KnightStats>().health--;
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.left * 10);

        }
    }
    private void OnCollisionExit(Collision collision)
    {

    }
}
