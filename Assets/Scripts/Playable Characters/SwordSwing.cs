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
    public AudioClip metalCollision;
    public GameObject ability3Icon;
    private AudioSource source;
    public GameObject Ability3;
    private GameObject player;
    private bool ab3OnCD;
    private bool AAOnCD;

    // Use this for initialization
    void Start () {
        ability3Icon = FindObjectOfType<A3ONCD>().gameObject;
        Ability3 = Resources.Load("Ability3") as GameObject;
        player = FindObjectOfType<KnightStats>().gameObject;
        swing = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        test = 0;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        AAOnCD = false;
        ab3OnCD = false;
    }
    public void reset() //this is used for picking up weapons, otherwise AA/ab3onCD may stay false
    {
        AAOnCD = false;
        ab3OnCD = false;
    }

    void Update ()
    {
        if (player.GetComponent<KnightStats>().UnlockAB3 == 0)
        {
            ability3Icon.SetActive(false);
        }
        else
        {
            ability3Icon.SetActive(true);
        }

        if (player.GetComponent<KnightStats>().weapon[0].gameObject.activeInHierarchy)
        {
            atkSpeedMod = .6f;
        }
        else
        {
            atkSpeedMod = 0f;
        }
        //ability 3 animation BEGIN
        if (Input.GetKey("3") && player.GetComponent<KnightStats>().energy>=10 && ab3OnCD == false && player.GetComponent<KnightStats>().UnlockAB3 == 1)
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
                var Projectile1 = Instantiate(Ability3, transform.position, transform.rotation);
                Projectile1.GetComponent<ability3Script>().AB3duration = Ability3.GetComponent<ability3Script>().AB3duration;
                Projectile1.GetComponent<ability3Script>().AB3Speed = Ability3.GetComponent<ability3Script>().AB3Speed;
                Projectile1.GetComponent<ability3Script>().AB3dmg = Ability3.GetComponent<ability3Script>().AB3dmg;
                Projectile1.GetComponent<ability3Script>().AB3Ultimate = Ability3.GetComponent<ability3Script>().AB3Ultimate;

                if (Projectile1.GetComponent<ability3Script>().AB3Ultimate == 1)
                {

                    StartCoroutine(ability3Ultimate());
                }
                Projectile1.gameObject.GetComponent<ability3Script>().test = 0;

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
        if (collision.gameObject.tag == "NPCSword")
        {
            source.clip = metalCollision;
            source.Play();
        }
        else
        {
          //  source.clip = swinging;
        }
        if (collision.gameObject.GetComponent<MonsterInterface>() != null)
        {
            //CombatTextManager.Instance.CreateText(collision.transform.position);
            collision.gameObject.GetComponent<MonsterInterface>().hp = collision.gameObject.GetComponent<MonsterInterface>().hp -player.GetComponent<KnightStats>().AD;
            if(collision.gameObject.GetComponent<SummonSkeleton>() != null){}
            else if (player.GetComponent<Player1Controls>().isFlippingLeft)
            {
                collision.GetComponent<Rigidbody>().velocity += new Vector3(-player.GetComponent<Player1Controls>().Ab1*10f, 0f, 0f);
            }
            if(collision.gameObject.GetComponent<SummonSkeleton>() != null){}
            else if (player.GetComponent<Player1Controls>().isFlippingRight)
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
        ability3Icon.GetComponent<Image>().fillAmount =0;
        ab3OnCD = true;
        ability3Icon.GetComponent<Image>().color = new Color32(128, 113, 113, 255);
        yield return new WaitForSeconds(1f);
        ability3Icon.GetComponent<Image>().color = Color.white;
        ab3OnCD = false;
    }
    IEnumerator ability3Ultimate()
    {
        yield return new WaitForSeconds(.8f);
        swing.SetInteger("state", 1);
        var Projectile2 = Instantiate(Ability3, transform.position, transform.rotation);
        Projectile2.GetComponent<ability3Script>().AB3duration = Ability3.GetComponent<ability3Script>().AB3duration;
        Projectile2.GetComponent<ability3Script>().AB3Speed = Ability3.GetComponent<ability3Script>().AB3Speed;
        Projectile2.GetComponent<ability3Script>().AB3dmg = Ability3.GetComponent<ability3Script>().AB3dmg;
        Projectile2.GetComponent<ability3Script>().AB3Ultimate = Ability3.GetComponent<ability3Script>().AB3Ultimate;
        Projectile2.gameObject.GetComponent<ability3Script>().test = 0;
        yield return new WaitForSeconds(.8f);
        swing.SetInteger("state", 1);
        var Projectile3 = Instantiate(Ability3, transform.position, transform.rotation);
        Projectile3.GetComponent<ability3Script>().AB3duration = Ability3.GetComponent<ability3Script>().AB3duration;
        Projectile3.GetComponent<ability3Script>().AB3Speed = Ability3.GetComponent<ability3Script>().AB3Speed;
        Projectile3.GetComponent<ability3Script>().AB3dmg = Ability3.GetComponent<ability3Script>().AB3dmg;
        Projectile3.GetComponent<ability3Script>().AB3Ultimate = Ability3.GetComponent<ability3Script>().AB3Ultimate;
        Projectile3.gameObject.GetComponent<ability3Script>().test = 0;
    }
}
