using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour {
    private GameObject player;
    float x;
    float z;
    float x2;
    int distance;
    float z2;
    float xdiff;
    float zdiff;
    private void Start()
    {
        if (Time.frameCount > 10)
        {
            StartCoroutine(DestroyArrow());
        }
    }
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
        player = FindObjectOfType<KnightStats>().gameObject;
        x = player.transform.position.x;
        z = player.transform.position.z;
        x2 = transform.position.x;
        z2 = transform.position.z;
        xdiff = (x - x2) * (x - x2)/100;
        zdiff = (z - z2) * (z - z2)/100;
        distance = 0;

    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Knight_Player")
        {
            int changeInHP = PlayerPrefs.GetInt("currentHP") - 1;
            if (collision.gameObject.GetComponent<KnightStats>().isRecovering)
            {

            }
        else
        {

            CombatTextManager.Instance.CreateText(collision.transform.position);
            PlayerPrefs.SetInt("currentHP", changeInHP);
            collision.gameObject.GetComponent<KnightStats>().isRecovering = true; //im a genius
                Destroy(gameObject);
            }
        collision.gameObject.GetComponent<KnightStats>().tempHP = collision.gameObject.GetComponent<KnightStats>().health;
        }
    }
    IEnumerator DestroyArrow()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
