using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightStats : MonoBehaviour {

    public int health;
    public int energy;
	// Use this for initialization
	void Start () {
        health = 10;
        energy = 100;
        InvokeRepeating("EnergyRegen", 1, 1);

    }

    // Update is called once per frame
    void Update () {
		
	}

    void EnergyRegen()
    {
        if(energy<=99)
        {
            energy++;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(health<=0)
        {
            this.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "npcSword")
        {
            health--;
        }

    }
}
