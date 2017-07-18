using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordSwing : MonoBehaviour {
    Animator swing;
    private int test;
    public float atkSpeedMod;
    public AudioClip swinging;
    public AudioClip ability3;
    public AudioClip hittingWood;
    public GameObject ab3;
    public GameObject ability3Icon;
    private AudioSource source;
    private GameObject player;
    private bool ab3OnCD;
    private bool AAOnCD;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<KnightStats>().gameObject;
        swing = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        test = 0;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        AAOnCD = false;
        ab3OnCD = false;
    }

    void Update ()
    {
        if(player.GetComponent<KnightStats>().weapon[0].gameObject.activeInHierarchy)
        {
            atkSpeedMod = .6f;
        }
        else
        {
            atkSpeedMod = 0f;
        }
        //ability 3 animation BEGIN
        if (Input.GetKey("3") && player.GetComponent<KnightStats>().energy>=10 && ab3OnCD == false)
        {
            if (swing.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                source.clip = ability3;
                source.Play();
                swing.Play("Ability3");
                swing.SetInteger("state", 3);
                test=1;
            }
            else if (swing.GetCurrentAnimatorStateInfo(0).IsName("Ability3") && test == 1)
            {
                swing.SetInteger("state", 4);
                test++;
            }
            else if (swing.GetCurrentAnimatorStateInfo(0).IsName("Ability3Hold") && test == 2)
            {
                swing.SetInteger("state", 1);
                var swordSwing = Instantiate(ab3, transform.position, transform.rotation);
                swordSwing.gameObject.GetComponent<ability3Script>().test = 0;

                test++;
                StartCoroutine(ability3CD());

            }
            else if (swing.GetCurrentAnimatorStateInfo(0).IsName("Ability3Hold") && test == 3)
            {
                swing.SetInteger("state", 0);
            }

        }
        //ability 3 animation END
        else if (Input.GetMouseButtonDown(0) && GetComponentInParent<KnightStats>().energy > 0 && !AAOnCD)
        {
            StartCoroutine(AutoAttack());
        }
        else if (!(Input.GetKey("a") && Input.GetKey("d")) && (Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("w") || Input.GetKey("s")) && !(Input.GetKey("s") && Input.GetKey("w")))
        {
            swing.SetInteger("state", 2);
        }
        else
            swing.SetInteger("state", 0);
    }
    //handles collisions
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<MonsterInterface>() != null)
        {
            //CombatTextManager.Instance.CreateText(collision.transform.position);

            collision.gameObject.GetComponent<MonsterInterface>().hp = collision.gameObject.GetComponent<MonsterInterface>().hp -player.GetComponent<KnightStats>().AD;
            if (player.GetComponent<Player1Controls>().isFlippingLeft)
            {
                collision.GetComponent<Rigidbody>().velocity += new Vector3(-player.GetComponent<Player1Controls>().Ab1*10f, 0f, 0f);
            }
            if (player.GetComponent<Player1Controls>().isFlippingRight)
            {
                collision.GetComponent<Rigidbody>().velocity += new Vector3(player.GetComponent<Player1Controls>().Ab1 * 10f, 0f, 0f);
            }
        }
    }

    IEnumerator AutoAttack()
    {
        AAOnCD = true;
        GetComponentInParent<KnightStats>().energy--;
        GetComponent<Collider>().enabled = true;
        swing.SetInteger("state", 1);
        source.clip = swinging;
        if (swing.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !swing.IsInTransition(0))
        {
            source.Play();
        }
        yield return new WaitForSeconds(.2f);
        GetComponent<Collider>().enabled = false;
        swing.SetInteger("state", 0);

        yield return new WaitForSeconds(PlayerPrefs.GetFloat("atkSpeed") - atkSpeedMod);
        AAOnCD = false;
    }

    IEnumerator ability3CD()
    {
        ab3OnCD = true;
        ability3Icon.GetComponent<Image>().color = new Color32(128, 113, 113, 255);
        yield return new WaitForSeconds(1f);
        ability3Icon.GetComponent<Image>().color = Color.white;
        ab3OnCD = false;
    }
}
