using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillTrainer : MonoBehaviour
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
        dialogue0 = "Potion Brewer: If you give me 100 gold, i'll train ya. (Give's Skill Point)";
        dialogue1 = "Potion Brewer: You look weak. I'll train ya, but it'll cost ya 100. (Give's Skill Point)";
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
                dManager.ShowBox(randomlyChosenDialogue, "SkillTrainer");
            }
        }
    }
}
