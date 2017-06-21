using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterVolume : MonoBehaviour
{
    public float masterVolume;
    public Button SaveChanges;
    // Use this for initialization
    void Start()
    {

        Button btn = SaveChanges.GetComponent<Button>();
        btn.onClick.AddListener(apply);
    }

    // Update is called once per frame
    void Update()
    {
        masterVolume = GameObject.Find("Master Volume Slider").GetComponent<Slider>().value;
        AudioListener.volume = PlayerPrefs.GetFloat("volume");

    }
    void apply()
    {
        AudioListener.volume = masterVolume;
        PlayerPrefs.SetFloat("volume", AudioListener.volume);
        PlayerPrefs.Save();
    }

}
