using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {
    public GameObject savedMusic;
    private GameObject[] gos;
    public Button dungeon;
    Scene CurrentScene;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Awake()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
        Button btn = dungeon.GetComponent<Button>();
        btn.onClick.AddListener(stopMusic);
        gos = GameObject.FindGameObjectsWithTag("bgMusic");
        DontDestroyOnLoad(this.savedMusic);

        if (gos.Length > 1)
        {
            Destroy((savedMusic));
        }
    }
    void button()
    {

    }
    void stopMusic()
    {
        Destroy((savedMusic));
    }
}
