using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldNPC : MonoBehaviour
{
    public GameObject thisSkeleton;
    // Use this for initialization
    void Start()
    {
        thisSkeleton = GetComponentInParent<SkeletonAI>().gameObject;
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
}
