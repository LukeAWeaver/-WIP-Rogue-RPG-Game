using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddPointSFX : MonoBehaviour {
    private AudioSource source;
    public AudioClip clickSFX;
    public Button sp;

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
        sp = gameObject.GetComponent<Button>();
        sp.onClick.AddListener(sfx);
        gameObject.GetComponent<Image>().color = Color.black;
    }

    // Update is called once per frame
    void Update () {
		
	}
    public void sfx()
    {
        Color skillLocked = Color.black;
        Color maxedSkill = Color.white;
        Color currentState = gameObject.GetComponent<Image>().color;
        if (currentState != skillLocked)
        {
            source.clip = clickSFX;
            source.Play();
        }
    }
    
}
