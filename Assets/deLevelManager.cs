using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deLevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<KnightStats>() != null)
        {
            if (SceneManager.GetActiveScene().name == "ForestBiome")
            {
                PlayerPrefs.SetInt("CurrentFloor", 0);
                SceneManager.LoadScene("OverWorld");
            }
            else if (SceneManager.GetActiveScene().name == "CemeteryBiome")
            {
                PlayerPrefs.SetInt("CurrentFloor", 0);
                SceneManager.LoadScene("ForestBiome");

            }
            else if (SceneManager.GetActiveScene().name == "DungeonBiome")
            {
                PlayerPrefs.SetInt("CurrentFloor", 3);
                SceneManager.LoadScene("CemeteryBiome");
            }
        }
    }
}
