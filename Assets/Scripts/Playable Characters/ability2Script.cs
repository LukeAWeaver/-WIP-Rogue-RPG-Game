using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ability2Script : MonoBehaviour {

    public GameObject knight;
    bool check;

    void Start ()
    {
      check = false;
    }

    // Update is called once per frame
    void Update ()
    {
      if(Input.GetKeyDown("2") && GetComponentInParent<KnightStats>().energy > 20)
      {
        check = !check;
      }
    }

    private void OnTriggerStay(Collider collision)
    {

      if(check && knight.GetComponent<KnightStats>().energy >20 && collision.gameObject.GetComponent<MonsterInterface>() != null)
      {
            collision.gameObject.GetComponent<MonsterInterface>().hp = collision.gameObject.GetComponent<MonsterInterface>().hp -knight.GetComponent<KnightStats>().AD;
            collision.GetComponent<Rigidbody>().velocity += new Vector3(-knight.GetComponent<Player1Controls>().Ab1*20f, 0f, 0f);
            check = false;
      }
    }

    private void OnCollisionExit(Collision collision)
    {

    }
  }
