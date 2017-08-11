using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spear : MonoBehaviour {
    public GameObject thisSkeleton;
    public Animator anim;
    // Use this for initialization
    private void Awake()
    {
        thisSkeleton = GetComponentInParent<SkeletonAI>().gameObject;
        anim = GetComponent<Animator>();

    }
    void Start () {

        anim.SetFloat("attack", 0);
    }

    // Update is called once per frame
    void Update () {
		
	}
    private void OnTriggerEnter(Collider collision)
    {
        int changeInHP = PlayerPrefs.GetInt("currentHP") - 2;
        if (collision.gameObject.GetComponent<KnightStats>() != null && !collision.gameObject.GetComponent<KnightStats>().isRecovering)
        {
            anim.SetFloat("attack", 1);
            StartCoroutine(AutoAttack());
            collision.GetComponent<Rigidbody>().velocity += new Vector3(0f, 3f, 0f);
            if (thisSkeleton.GetComponent<MonsterInterface>().isFlippingLeft)
            {
                collision.GetComponent<Rigidbody>().velocity += new Vector3(-16f, 0f, 0f);
            }
            if (thisSkeleton.GetComponent<MonsterInterface>().isFlippingRight)
            {
                collision.GetComponent<Rigidbody>().velocity += new Vector3(16f, 0f, 0f);
            }
            //CombatTextManager.Instance.CreateText(collision.transform.position);
            PlayerPrefs.SetInt("currentHP", changeInHP);
            collision.gameObject.GetComponent<KnightStats>().isRecovering = true;
            //source.clip = thud;
            //source.Play();

        }
    }
    IEnumerator AutoAttack()
    {
        yield return new WaitForSeconds(.8f);
        anim.SetFloat("attack", 0);

    }

}
