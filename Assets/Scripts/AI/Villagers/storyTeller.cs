using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storyTeller : MonoBehaviour
{
    private string dialogue0;
    private string dialogue1;
    private string randomlyChosenDialogue;
    private int randomlyChosenNumberForDialogue;
    private string npc;
    private DialogueManager dManager;
    private AudioSource source;
    public AudioClip speech;

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = speech;
        npc = "SkillTrainer";
        dManager = FindObjectOfType<DialogueManager>();
        dialogue0 = "Story Teller: You are the culmination of a group of people making a game. You gotta play it.";
        dialogue1 = "Story Teller: You try to kill the dragon at the end of the path in the castle. That is your purpose.";
    }

    // Update is called once per frame
    void Update()
    {
        randomlyChosenNumberForDialogue = Random.Range(0, 2);
        if (randomlyChosenNumberForDialogue == 0)
            randomlyChosenDialogue = dialogue0;
        else if (randomlyChosenNumberForDialogue == 1)
        {
            randomlyChosenDialogue = dialogue1;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Knight_Player")
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                source.Play();
                dManager.ShowBox(randomlyChosenDialogue, "storyTeller");
            }
        }
    }
}
