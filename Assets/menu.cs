using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour {

    Rect _quitWindowRect = new Rect(Screen.width / 2 - 125, Screen.height / 2 - 25, 250, 50);

    void OnGUI()
    {
        if (Input.GetKey("27"))
        {
            GUI.Window(2222, _quitWindowRect, QuitWindowFunction, "Quit?");
        }
    }

    void QuitWindowFunction(int id)
    {
        if (GUI.Button(new Rect(10, 10, 100, 30), "yes"))
        {
            // TODO: shut down the game...
        }
        if (GUI.Button(new Rect(120, 10, 100, 30), "NO!!"))
        {
            // TODO: return to game
        }

    }
}
