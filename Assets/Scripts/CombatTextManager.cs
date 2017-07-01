using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatTextManager : MonoBehaviour {
    public static float health;
    private static CombatTextManager instance;
    public GameObject text;
    public RectTransform canvasTransform;
    public static CombatTextManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<CombatTextManager>();
            }
            return instance;
        }
    }
    public void CreateText(Vector3 position)
    {

       GameObject src =  Instantiate(text, position, Quaternion.identity);
        src.transform.SetParent(canvasTransform);
        instance.transform.position = new Vector2(this.transform.position.x + Random.Range(-5f, 5f), this.transform.position.y + Random.Range(-.2f, .2f));
        src.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

    }
}
