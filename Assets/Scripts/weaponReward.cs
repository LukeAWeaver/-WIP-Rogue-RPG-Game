using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponReward : MonoBehaviour {
    public GameObject text;
    public GameObject player;
    public Sprite[] weapons;
    public GameObject[] playerWeapons; //0 wooden sword, 1 2h, 2 vampiric sword
    public bool isNear;
    private int rng;
    Canvas canvas;
	// Use this for initialization
	void Start () {
        weapons = new Sprite[4];
        playerWeapons = new GameObject[4];
        canvas = FindObjectOfType<Canvas>();
        text = FindObjectOfType<weaponPickUpText>().gameObject;
        text.GetComponentInChildren<Image>().enabled = false;
        text.GetComponentInChildren<Text>().enabled = false;
        //        text = Resources.Load("WeaponPickUpText") as GameObject;
        text.SetActive(true);
        weapons[1] = Resources.Load<Sprite>("woodenSword");
        weapons[2] = Resources.Load<Sprite>("2HLS");
        weapons[3] = Resources.Load<Sprite>("redSword");
        //text.transform.SetParent(canvas.transform);
        rng = Random.Range(1, weapons.Length);
        player = FindObjectOfType<KnightStats>().gameObject;
        gameObject.GetComponent<SpriteRenderer>().sprite = weapons[rng];
        GetComponent<Transform>().localScale = new Vector3(.55f, .55f, .55f);
        GetComponent<Transform>().localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 2f, transform.localPosition.z);
        foreach (Transform child in player.transform)
        {
            if(child.name == "LArm")
            {
                playerWeapons[0] = child.gameObject;
            }
            else if (child.name == "PlayerWoodenSword")
            {
                playerWeapons[1] = child.gameObject;
            }
            else if (child.name == "2HS")
            {
                playerWeapons[2] = child.gameObject;
            }
            else if (child.name == "1HVampiricSword")
            {
                playerWeapons[3] = child.gameObject;
            }
        }
    }

    // Update is called once per frame
    void Update () {
		if(isNear && Input.GetKeyDown(KeyCode.Space))
        {
            if (rng == 2) //if rng is 2 then the player is using a 2h weapon
            {
                playerWeapons[0].SetActive(false); //disable left arm
            }
            else
            {
                playerWeapons[0].SetActive(true);
            }
            if (playerWeapons[1].activeInHierarchy) //replace wood weapon with..
            {
                if (gameObject.GetComponent<SpriteRenderer>().sprite == weapons[1]) // same weapon, do nothing
                {

                }
                else                                //something else
                {
                    playerWeapons[1].SetActive(false);
                    playerWeapons[rng].SetActive(true);
                    playerWeapons[rng].GetComponent<SwordSwing>().reset();
                    gameObject.GetComponent<SpriteRenderer>().sprite = weapons[1];
                    player.GetComponent<KnightStats>().currentWeapon = rng;
                    rng = 1;
                }
            }
            else if (playerWeapons[2].activeInHierarchy) //2h
            {
                if (gameObject.GetComponent<SpriteRenderer>().sprite == weapons[2]) //if its the same weapon, do nothing
                {

                }
                else
                {
                    playerWeapons[2].SetActive(false);
                    playerWeapons[rng].SetActive(true);
                    playerWeapons[rng].GetComponent<SwordSwing>().reset();
                    gameObject.GetComponent<SpriteRenderer>().sprite = weapons[2];
                    player.GetComponent<KnightStats>().currentWeapon = rng;
                    rng = 2;
                }
            }
            else if (playerWeapons[3].activeInHierarchy) //vampiric sword
            {
                if (gameObject.GetComponent<SpriteRenderer>().sprite == weapons[3]) //if its the same weapon, do nothing
                {

                }
                else
                {
                    playerWeapons[3].SetActive(false);
                    playerWeapons[rng].SetActive(true);
                    playerWeapons[rng].GetComponent<SwordSwing>().reset();
                    gameObject.GetComponent<SpriteRenderer>().sprite = weapons[3];
                    player.GetComponent<KnightStats>().currentWeapon = rng;
                    rng = 3;
                }
            }
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Knight_Player")
        {
            isNear = true;
            text.GetComponentInChildren<Image>().enabled = true;
            text.GetComponentInChildren<Text>().enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Knight_Player")
        {
            isNear = false;
            text.GetComponentInChildren<Image>().enabled = false;
            text.GetComponentInChildren<Text>().enabled = false;
        }
    }
}
