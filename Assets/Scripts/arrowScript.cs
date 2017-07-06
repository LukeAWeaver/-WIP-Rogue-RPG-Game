using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour {
    public GameObject player;
    float x;
    float z;
    float x2;
    int distance;
    float z2;
    float xdiff;
    float zdiff;
    // Use this for initialization
    void start() {

    }

    // Update is called once per frame
    void Update() {
        if (distance < 120)
        {
            if (x2 > x && z2 < z)
            {
                transform.Translate(-xdiff, 0f, zdiff);
            }
            if (x2 > x && z2 > z)
            {
                transform.Translate(-xdiff, 0f, -zdiff);
            }
            if (x2 < x && z2 < z)
            {
                transform.Translate(xdiff, 0f, zdiff);
            }
            if(x2 < x && z2 > z)
            {
                transform.Translate(xdiff, 0f, -zdiff);
            }
            distance++;
        }

    }
    public void Awake()
    {
        x = player.transform.position.x;
        z = player.transform.position.z;
        x2 = transform.position.x;
        z2 = transform.position.z;
        xdiff = (x - x2) * (x - x2)/100;
        zdiff = (z - z2) * (z - z2)/100;
        distance = 0;

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Knight_Player")
        {
            if (collision.gameObject.GetComponent<KnightStats>().isRecovering)
            {

            }
        else
        {
                CombatTextManager.Instance.CreateText(collision.transform.position);
                collision.GetComponent<KnightStats>().health--; //im a genius
            collision.gameObject.GetComponent<KnightStats>().isRecovering = true; //im a genius
            this.gameObject.SetActive(false);
        }
        collision.gameObject.GetComponent<KnightStats>().tempHP = collision.gameObject.GetComponent<KnightStats>().health;
        }
    }
}
