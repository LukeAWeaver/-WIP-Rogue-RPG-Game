using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AB3Tier4Text : MonoBehaviour
{
    Text text;
    private GameObject thisSkill;
    private GameObject player;
    public GameObject Ability3;

    // Use this for initialization
    void Start()
    {
        Ability3 = Resources.Load("Ability3") as GameObject;
        player = FindObjectOfType<KnightStats>().gameObject;
        text = GetComponent<Text>();
        thisSkill = FindObjectOfType<AB3T4>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = (Ability3.GetComponent<ability3Script>().AB3Ultimate).ToString() + "/1";
    }
}
