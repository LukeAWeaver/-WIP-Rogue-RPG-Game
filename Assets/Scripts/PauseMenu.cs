using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    //WIP SOMEONE FIX PLS
    public bool isPaused;
	// Use this for initialization
	void Start () {
        isPaused = false;
         
    }
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {  
            isPaused = false;
            Time.timeScale = 0f;
        }
        if(Input.GetKey("escape") && !isPaused)
        {
            SceneManager.LoadScene("TitleScreen"); //TEMP SOLUTION, BRINGS TO TITLE SCREEN
            isPaused = true;
            Time.timeScale = 1f;
        }
	}
}
