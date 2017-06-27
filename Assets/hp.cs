using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp : MonoBehaviour {
    public Sprite[] hpLeft;
    public SpriteRenderer currentHp;
	// Use this for initialization
	void Start () {
        currentHp.sprite = hpLeft[0];
	}
	
	// Update is called once per frame
	void Update () {
        currentHp.sprite = hpLeft[2];

    }
}
