using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AI : MonoBehaviour {
    bool turn;
    public string flip;
    public GameObject player;
    public goblinInterface Thisgoblin;
    public GameObject npc;

	// Use this for initialization
	void Start () {
        turn = false;
        /*var original = EditorBuildSettings.scenes;
        var newSettings = new EditorBuildSettingsScene[original.Length + 1];
        System.Array.Copy(original, newSettings, original.Length);
        var sceneToAdd = new EditorBuildSettingsScene("Assets/level1", false);
        newSettings[newSettings.Length - 1] = sceneToAdd;
        EditorBuildSettings.scenes = newSettings;
        */
    }



    // Update is called once per frame
    void Update() 
{
        if(Thisgoblin.hp ==0)
        {
            npc.SetActive(false);
        }
        var follow = player.transform.position;
        if(transform.position.x > follow.x)
        {
            Flip("right");
            transform.Translate(-Thisgoblin.ms, 0f, 0f);
        }
        else
        {
            Flip("left");
            transform.Translate(Thisgoblin.ms, 0f, 0f);

        }
        if(transform.position.y > follow.y)
        {
            transform.Translate(0f, -Thisgoblin.ms, 0f);
        }
        else
        {
            transform.Translate(0f, Thisgoblin.ms, 0f);
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
    public void Flip(string Methodflip)
    {
        flip = Methodflip;
        var theScale = transform.localScale;
        if (Methodflip == "left")
        {
            if (theScale.x < -.1f)
                theScale.x = -theScale.x;
        }
        if (Methodflip == "right")
        {
            if (theScale.x > .1f)
                theScale.x = -theScale.x;
        }
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "1dmg")
        {
            Thisgoblin.hp--;
        }
        if (Thisgoblin.hp == 2)
        {
            Thisgoblin.ms = .1f;
        }

    }
}
