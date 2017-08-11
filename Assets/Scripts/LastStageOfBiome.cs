using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastStageOfBiome : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetInt("CurrentFloor") == 2 || PlayerPrefs.GetInt("CurrentFloor") == 5 || PlayerPrefs.GetInt("CurrentFloor") == 8)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
