using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour {
    public GameObject dBox;
    public GameObject guardIcon;
    public Text dtext;
    public bool dialogActive;
	// Use this for initialization
	void Start () {
        dialogActive = false;
        dBox.SetActive(false);
        guardIcon.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(dialogActive && Input.GetKeyDown(KeyCode.Space))
        {
            dBox.SetActive(false);
            dialogActive = false;
            guardIcon.SetActive(false);
        }
	}
    public void ShowBox(string dialogue,string npc)
    {
        dialogActive = true;
        dBox.SetActive(true);
        dtext.text = dialogue;
        guardIcon.SetActive(true);
        if(npc == "guard")
        {
            guardIcon.SetActive(true);
        }
        if(npc == "PotionBrewer")
        {
            guardIcon.SetActive(false);
        }
    }
}
