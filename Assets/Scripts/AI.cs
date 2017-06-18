using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AI : MonoBehaviour {
    bool turn;
    int ctr;



	// Use this for initialization
	void Start () {
        turn = false;
        ctr = 359;
        /*var original = EditorBuildSettings.scenes;
        var newSettings = new EditorBuildSettingsScene[original.Length + 1];
        System.Array.Copy(original, newSettings, original.Length);
        var sceneToAdd = new EditorBuildSettingsScene("Assets/level1", false);
        newSettings[newSettings.Length - 1] = sceneToAdd;
        EditorBuildSettings.scenes = newSettings;
        */
    }



    // Update is called once per frame
    void Update() {

        ctr++;
        if (ctr % 360 == 0)
        {
            if(ctr%720 ==0)
            {

                //SceneManager.LoadScene("level1");
            }
            turn = !turn;
            if (!turn)
            {
                Flip("left");
            }
            else
                Flip("right");
        }
        if (turn)
        {
            transform.Translate(-.04f, 0f, 0f); //left
        }
        else
        {
            transform.Translate(.04f, 0f, 0f); //right

        }



    }
    public void Flip(string flip)
    {
        var theScale = transform.localScale;
        if (flip == "left")
        {
            if (theScale.x < -.1f)
                theScale.x = -theScale.x;
        }
        if (flip == "right")
        {
            if (theScale.x > .1f)
                theScale.x = -theScale.x;
        }
        transform.localScale = theScale;
    }
}
