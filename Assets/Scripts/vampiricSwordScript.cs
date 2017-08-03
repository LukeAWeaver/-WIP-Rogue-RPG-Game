using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vampiricSwordScript : MonoBehaviour {
    public int hitsLeft;
    public int currentHP;

    // Use this for initialization
    void Start () {
        hitsLeft = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(hitsLeft-4 >= 0)
        {
            hitsLeft = 0;
            currentHP = PlayerPrefs.GetInt("currentHP") + 1;
            PlayerPrefs.SetInt("currentHP", currentHP);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<MonsterInterface>() != null)
        {
            Debug.Log("collision detected");
            hitsLeft++;

    

        }
    }
}
