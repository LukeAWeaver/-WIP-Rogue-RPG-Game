using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goldScript : MonoBehaviour
{
    public GameObject player;

    Text text;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<KnightStats>().gameObject;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<KnightStats>().gold > 0)
            text.text = "X" + player.GetComponent<KnightStats>().gold.ToString();
        else if (player.GetComponent<KnightStats>().gold == 0)
        {
            text.text = "X0";
        }
    }
}
