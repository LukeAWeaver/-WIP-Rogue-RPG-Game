using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ability1Script : MonoBehaviour {

    public GameObject knight;
    public GameObject[] weapons;

    bool check;
    // Use this for initialization
    void Start ()
    {
        check = false;
    }
    // Update is called once per frame
    void Update ()
    {
      if(Input.GetKeyDown("1") && GetComponentInParent<KnightStats>().energy > 0)
      {
        check = !check;

      }
      if(check && knight.GetComponent<KnightStats>().energy >0)
      {
        knight.GetComponent<Player1Controls>().Ab1=1.5f;
        knight.GetComponent<KnightStats>().Ab1=2;
        knight.GetComponent<SpriteRenderer>().color = Color.red;
        foreach(GameObject weapon in weapons)
            {
                weapon.GetComponent<SpriteRenderer>().color = Color.red;
            }
        knight.GetComponent<KnightStats>().energy=knight.GetComponent<KnightStats>().energy-.1f;
      }
      if(!check || knight.GetComponent<KnightStats>().energy < 1)
      {
        check = false;
        knight.GetComponent<Player1Controls>().Ab1=1f;
        knight.GetComponent<KnightStats>().Ab1=1;
        knight.GetComponent<SpriteRenderer>().color = Color.white;
            foreach (GameObject weapon in weapons)
            {
                weapon.GetComponent<SpriteRenderer>().color = Color.white;
            }

        }
    }
  }
