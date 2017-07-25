using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enterDungeon : MonoBehaviour {
    FadeManager fm;
	// Use this for initialization
	void Start () {
        fm = FindObjectOfType<FadeManager>();
       // fm.fadeImage.color = Color.Lerp(new Color(1, 1, 1, 0), Color.black, fm.transition);
    }

    // Update is called once per frame
    void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            fm.Fade(true, 1.25f);
            StartCoroutine(transition());
        }
    }

    IEnumerator transition()
    {

        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene("Floor1");

    }
}
