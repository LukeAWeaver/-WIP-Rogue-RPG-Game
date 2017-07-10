using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardInteraction : MonoBehaviour {
    private string dialogue0;
    private string dialogue1;
    private string randomlyChosenDialogue;
    private int randomlyChosenNumberForDialogue;
    private string guard;
    private DialogueManager dManager;
	// Use this for initialization
	void Start () {
        guard = "guard";
        dManager = FindObjectOfType<DialogueManager>();
        dialogue0 = "Guard: Be careful, many heroes have delved down there but none have yet to return.";
        dialogue1 = "Guard: Do you have any relatives? You look a lot like the last guy to go down there.";
	}
	
	// Update is called once per frame
	void Update () {
        randomlyChosenNumberForDialogue = Random.Range(0, 2);
        if (randomlyChosenNumberForDialogue == 0)
            randomlyChosenDialogue = dialogue0;
        else if(randomlyChosenNumberForDialogue == 1)
        {
            randomlyChosenDialogue = dialogue1;
        }
	}
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Knight_Player")
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                dManager.ShowBox(randomlyChosenDialogue,guard);
            }
        }
    }
}
