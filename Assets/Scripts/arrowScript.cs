using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour {
    public GameObject player;
    float x;
    float y;
    float x2;
    int distance;
    float y2;
    float xdiff;
    float ydiff;
    // Use this for initialization
    void start() {

    }

    // Update is called once per frame
    void Update() {
        if (distance < 120)
        {
            if (x2 > x && y2 < y)
            {
                transform.Translate(-xdiff, ydiff, 0f);
            }
            if (x2 > x && y2 > y)
            {
                transform.Translate(-xdiff, -ydiff, 0f);
            }
            if (x2 < x && y2 < y)
            {
                transform.Translate(xdiff, ydiff, 0f);
            }
            if(x2 < x && y2 > y)
            {
                transform.Translate(xdiff, -ydiff, 0f);
            }
            distance++;
        }

    }
    public void Awake()
    {
        x = player.transform.position.x;
        y = player.transform.position.y;
        x2 = transform.position.x;
        y2 = transform.position.y;
        xdiff = (x - x2) * (x - x2)/100;
        ydiff = (y - y2) * (y - y2)/100;
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
