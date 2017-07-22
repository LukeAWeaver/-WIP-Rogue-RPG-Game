using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour {
    public GameObject dBox;
    public GameObject playerReplyYes;
    public GameObject playerReplyNo;
    public GameObject guardIcon;
    public GameObject BrewerIcon;
    public GameObject playerIcon;
    public GameObject player;
    public GameObject healthPots;
    public GameObject[] AbilityIcons;
    private string npc;
    public Text dtext;
    public bool dialogActive;
	// Use this for initialization
	void Start () {
        dialogActive = false;
        dBox.SetActive(false);
        guardIcon.SetActive(false);
        BrewerIcon.SetActive(false);
        playerIcon.SetActive(false);
        playerReplyNo.SetActive(false);
        playerReplyYes.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) //movement disables dialog box
        {
            dialogActive = false;
            dBox.SetActive(false);
            guardIcon.SetActive(false);
            BrewerIcon.SetActive(false);
            playerIcon.SetActive(false);
            playerReplyNo.SetActive(false);
            playerReplyYes.SetActive(false);
            foreach (GameObject Icon in AbilityIcons)
            {
                Icon.SetActive(true);
            }
        }
        if (dialogActive && Input.GetKeyDown(KeyCode.E))
        {
            playerReplyYes.SetActive(false);
            playerReplyNo.SetActive(false);
            playerIcon.SetActive(false);
            dBox.SetActive(false);
            dialogActive = false;
            guardIcon.SetActive(false);
            BrewerIcon.SetActive(false);
            foreach (GameObject Icon in AbilityIcons)
            {
                Icon.SetActive(true);
            }
            npc = "None";
        }
        //Potion Brewer Interactions
        if (npc == "PotionBrewer" && dialogActive)
        {
            playerIcon.SetActive(true);
            if(!playerReplyNo.activeInHierarchy)
            {
                playerReplyYes.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                playerReplyYes.SetActive(true);
                playerReplyNo.SetActive(false);

            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                playerReplyYes.SetActive(false);
                playerReplyNo.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (playerReplyYes.activeInHierarchy && player.GetComponent<KnightStats>().gold>=5)
                {
                    healthPots.GetComponent<PlayerPotions>().hpPot++;
                    player.GetComponent<KnightStats>().gold = player.GetComponent<KnightStats>().gold - 5;
                }
                playerIcon.SetActive(false);
                playerReplyNo.SetActive(false);
                playerReplyYes.SetActive(false);
                BrewerIcon.SetActive(false);
                dBox.SetActive(false);
                foreach (GameObject Icon in AbilityIcons)
                {
                    Icon.SetActive(true);
                }
                npc = "None";
            }
        }
    }
    public void ShowBox(string dialogue,string npc)
    {
        dialogActive = true;
        dBox.SetActive(true);
        dtext.text = dialogue;
        if(npc == "guard")
        {
            guardIcon.SetActive(true);
        }
        if(npc == "PotionBrewer")
        {
            guardIcon.SetActive(false);
            BrewerIcon.SetActive(true);
            this.npc = npc;
        }
        foreach (GameObject Icon in AbilityIcons)
        {
            Icon.SetActive(false);
        }
    }

}
