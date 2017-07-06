using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowScript : MonoBehaviour
{
    public GameObject arrow;
    Animator swing;
    public float range;
    public GameObject player;
    public int counter;
    public AudioClip arrowShot;
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
        var target = player.transform.position;
        range = Mathf.Sqrt((target.x - transform.position.x) * (target.x - transform.position.x) + (target.z - transform.position.z) * (target.z - transform.position.z));
        if (range < 5)
        {
            counter++;
            swing.SetBool("inRange", true);
            if (counter % 180 == 0)
            {
                ShootArrow();
            }
        }
        else
            swing.SetBool("inRange", false);
    }
    public void ShootArrow()
    {
        var ThisEnemy = Instantiate(arrow, transform.position, transform.rotation);
        source.clip = arrowShot;
        source.Play();
    }
}
