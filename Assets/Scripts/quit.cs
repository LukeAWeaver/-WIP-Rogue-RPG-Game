using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class quit: MonoBehaviour
{
    public Button dungeon;
    // Use this for initialization
    void Start()
    {
        Button btn = dungeon.GetComponent<Button>();
        btn.onClick.AddListener(changeScene);

    }

    // Update is called once per frame
    void Update()
    {

    }
    void changeScene()
    {
        Application.Quit();
    }
}
