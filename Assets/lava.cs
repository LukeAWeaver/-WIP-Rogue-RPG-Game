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
        if ((other.gameObject.GetComponent<MonsterInterface>() !=null) && !(other is SphereCollider))
        {
            other.GetComponent<Rigidbody>().velocity += new Vector3(0f, 10f, 0f);
            other.GetComponent<MonsterInterface>().hp--;
        }
        if (other.gameObject.GetComponent<KnightStats>() != null && !other.gameObject.GetComponent<KnightStats>().isRecovering)
        {
            other.GetComponent<Rigidbody>().velocity += new Vector3(0f, 2f, 0f);
            int changeInHP = PlayerPrefs.GetInt("currentHP") - 1;
            PlayerPrefs.SetInt("currentHP", changeInHP);
            other.gameObject.GetComponent<KnightStats>().isRecovering = true;
        }
        if (other.gameObject.GetComponent<KnightStats>() != null)
        {
            other.GetComponent<Rigidbody>().velocity += new Vector3(0f, 15f, 0f);

            other.gameObject.GetComponent<KnightStats>().isRecovering = true;
        }
    }
}
