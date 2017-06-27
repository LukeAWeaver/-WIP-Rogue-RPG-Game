using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AI : MonoBehaviour {
    public string flip;
    public GameObject player;
    public goblinInterface Thisgoblin;
    public GameObject npc;

	// Use this for initialization
	void Start () {
    }



    // Update is called once per frame
    void Update() 
{
        if(Thisgoblin.hp ==0)
        {
            npc.SetActive(false);
        }
        var target = player.transform.position;
        if(transform.position.x > target.x)
        {
            Flip("right");
            transform.Translate(-Thisgoblin.ms, 0f, 0f);
        }
        else if (transform.position.x < target.x)
        {
            Flip("left");
            transform.Translate(Thisgoblin.ms, 0f, 0f);

        }
        if(transform.position.y > target.y)
        {
            transform.Translate(0f, -Thisgoblin.ms, 0f);
        }
        else
        {
            transform.Translate(0f, Thisgoblin.ms, 0f);
        }






    }
    public void Flip(string Methodflip)
    {
        flip = Methodflip;
        var theScale = transform.localScale;
        if (Methodflip == "left")
        {
            if (theScale.x < 0f)
                theScale.x = -theScale.x;
        }
        if (Methodflip == "right")
        {
            if (theScale.x > 0f)
                theScale.x = -theScale.x;
        }
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


    }
}
