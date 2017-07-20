using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ability2Script : MonoBehaviour {

    public GameObject knight;
    bool check;

    void Start ()
    {
        gameObject.GetComponent<Collider>().enabled = false;
      check = false;
    }

    // Update is called once per frame
    void Update ()
    {
      if(Input.GetKeyDown("2") && GetComponentInParent<KnightStats>().energy > 20)
      {
            gameObject.GetComponent<Collider>().enabled = true;
            check = !check;
        knight.GetComponent<KnightStats>().energy = knight.GetComponent<KnightStats>().energy - 20;
      }
    }

    private void OnTriggerStay(Collider collision)
    {

      if(check && knight.GetComponent<KnightStats>().energy >20 && collision.gameObject.GetComponent<MonsterInterface>() != null)
      {
        //Top
        if(collision.gameObject.transform.position.z < knight.transform.position.z)
        {
          collision.gameObject.GetComponent<MonsterInterface>().hp = collision.gameObject.GetComponent<MonsterInterface>().hp -knight.GetComponent<KnightStats>().AD;
          collision.GetComponent<Rigidbody>().velocity += new Vector3(-knight.GetComponent<Player1Controls>().Ab1*0f, 0f, 20f);
          check = false;
        }
        //Bottom
        if(collision.gameObject.transform.position.z > knight.transform.position.z)
        {
          collision.gameObject.GetComponent<MonsterInterface>().hp = collision.gameObject.GetComponent<MonsterInterface>().hp -knight.GetComponent<KnightStats>().AD;
          collision.GetComponent<Rigidbody>().velocity += new Vector3(knight.GetComponent<Player1Controls>().Ab1*0f, 0f, 20f);
          check = false;
        }
        //Left
        if(collision.gameObject.transform.position.x < knight.transform.position.x)
        {
          collision.gameObject.GetComponent<MonsterInterface>().hp = collision.gameObject.GetComponent<MonsterInterface>().hp -knight.GetComponent<KnightStats>().AD;
          collision.GetComponent<Rigidbody>().velocity += new Vector3(-knight.GetComponent<Player1Controls>().Ab1*20f, 0f, 0f);
          check = false;
        }
        //Right
        if(collision.gameObject.transform.position.x > knight.transform.position.x)
        {
          collision.gameObject.GetComponent<MonsterInterface>().hp = collision.gameObject.GetComponent<MonsterInterface>().hp -knight.GetComponent<KnightStats>().AD;
          collision.GetComponent<Rigidbody>().velocity += new Vector3(knight.GetComponent<Player1Controls>().Ab1*20f, 0f, 0f);
          check = false;
        }
      }
    }

    private void OnCollisionExit(Collision collision)
    {
        gameObject.GetComponent<Collider>().enabled = false;
    }
}
