using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class A4ONCD : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("onCD", 0, 0.01f);

    }

    // Update is called once per frame
    void Update()
    {

    }
    void onCD()
    {
        if (gameObject.GetComponent<Image>().fillAmount < 1f)
        {
            gameObject.GetComponent<Image>().fillAmount = gameObject.GetComponent<Image>().fillAmount + .001f;
        }
    }
}
