using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightStats : MonoBehaviour {

    public int health;
    public int tempHP;
    public int energy;
    public float timer;
    public bool isRecovering;
	// Use this for initialization
	void Start () {
        isRecovering = false;
        timer = 0;
        health = 12;
        tempHP = 12;
        energy = 100;
        InvokeRepeating("resetHP", 0, .03f);
    }

    // Update is called once per frame
    void Update ()
    {
        if(health <1)
        {
            this.gameObject.SetActive(false);
        }
	}

    public void resetHP()
    {
        if (isRecovering)
        {
            if(timer < 60)
            {
                Debug.Log(timer);
                timer++;
            }
            else
            {
                timer = 0;
                isRecovering = false;
            }
     
            
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
}
