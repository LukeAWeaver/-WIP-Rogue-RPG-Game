using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<KnightStats>() !=null || other.gameObject.GetComponent<MonsterInterface>() !=null)
        {
            other.GetComponent<Rigidbody>().velocity += new Vector3(0f, 15f, 0f);
        }
        if (other.gameObject.GetComponent<KnightStats>() != null && !other.gameObject.GetComponent<KnightStats>().isRecovering)
        {
            int changeInHP = PlayerPrefs.GetInt("currentHP") - 1;
            other.GetComponent<Rigidbody>().velocity += new Vector3(0f, 2f, 0f);
            PlayerPrefs.SetInt("currentHP", changeInHP);
            other.gameObject.GetComponent<KnightStats>().isRecovering = true;


        }
    }
}
