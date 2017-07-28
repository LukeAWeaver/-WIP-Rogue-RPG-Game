using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AB1DOT : MonoBehaviour {
    public int ultimateEnabled;
    private MonsterInterface npc;
	// Use this for initialization
	void Start () {
        ultimateEnabled = PlayerPrefs.GetInt("ultimateEnabled");

    }

    // Update is called once per frame
    void Update () {
        PlayerPrefs.SetInt("ultimateEnabled", ultimateEnabled);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<MonsterInterface>() != null && gameObject.GetComponent<ability1Script>().isActiveToggle == 4 && ultimateEnabled == 1)
        {
            npc = other.gameObject.GetComponent<MonsterInterface>();
            npc.exitBurningRadius = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<MonsterInterface>() != null)
        {
            npc = other.gameObject.GetComponent<MonsterInterface>();
            npc.exitBurningRadius = true;
        }
    }
}
