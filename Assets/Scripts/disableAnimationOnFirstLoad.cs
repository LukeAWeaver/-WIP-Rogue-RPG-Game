using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableAnimationOnFirstLoad : MonoBehaviour {
    private GameObject AB2;
    private ability3Script AB3;
    private GameObject AB4;
    int counter;

    // Use this for initialization
    void Start () {
      //  AB2 = FindObjectOfType<ability2Script>().gameObject;
      //  AB3 = FindObjectOfType<ability3Script>();
      //  AB4 = FindObjectOfType<ability4Script>().gameObject;

    }

    // Update is called once per frame
    void Update () {
		if(counter>300)
        {
        //    AB3.enabled = true;
        }


    }

}
