using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour {
    public static FadeManager Instance { set; get;}
    public Image fadeImage;
    private bool isInTransition;
    private bool isShowing;
    public float transition;
    private float duration;
	// Use this for initialization
	void Start () {
		
	}
    private void Awake()
    {
        Instance = this;
    }
    // Update is called once per frame
    private void Update () {

		if(!isInTransition)
        {
            return;
        }
        transition += (isShowing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
        fadeImage.color = Color.Lerp(new Color(1, 1, 1, 0), Color.black, transition);
        if(transition>1 || transition < 0)
        {
            isInTransition = false;
        }
	}
    public void Fade(bool showing, float duration)
    {
        isShowing = showing;
        isInTransition = true;
        this.duration = duration;
        transition = (isShowing) ? 0 : 1;
    }
}
