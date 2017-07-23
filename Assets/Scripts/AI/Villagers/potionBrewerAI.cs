using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potionBrewerAI : MonoBehaviour
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
        npc = "PotionBrewer";
        dManager = FindObjectOfType<DialogueManager>();
        dialogue0 = "Potion Brewer: Ahh.. another adventurer. I'll sell you potions for 5 gold coins.";
        dialogue1 = "Potion Brewer: You want some potions do ya? I'll sell em to ya for 5 Gold coins.";
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
                dManager.ShowBox(randomlyChosenDialogue, "PotionBrewer");
            }
        }
    }
}
