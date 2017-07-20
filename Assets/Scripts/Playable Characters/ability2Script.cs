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
      else if(Input.GetKeyUp("2"))
      {
        gameObject.GetComponent<Collider>().enabled = false;
      }
    }

    private void OnTriggerStay(Collider collision)
    {
      if(check && knight.GetComponent<KnightStats>().energy >20 && collision.gameObject.GetComponent<MonsterInterface>() != null)
      {
        check = false;
        collision.gameObject.GetComponent<MonsterInterface>().hp = collision.gameObject.GetComponent<MonsterInterface>().hp -knight.GetComponent<KnightStats>().AD;
        //Top
        if(collision.gameObject.transform.position.z > knight.transform.position.z)
        {
            collision.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 15f);
            //Left
            if(collision.gameObject.transform.position.x < knight.transform.position.x)
            {
                collision.GetComponent<Rigidbody>().velocity = new Vector3(-15f, 0f, 0f);
            }
            //Right
            else if(collision.gameObject.transform.position.x > knight.transform.position.x)
            {
                collision.GetComponent<Rigidbody>().velocity = new Vector3(15f, 0f, 0f);
            }
        }
        //Bottom
       else if(collision.gameObject.transform.position.z < knight.transform.position.z)
        {
            collision.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, -15f);
            //Left
            if(collision.gameObject.transform.position.x < knight.transform.position.x)
            {
                collision.GetComponent<Rigidbody>().velocity = new Vector3(-15f, 0f, 0f);
            }
            //Right
            else if(collision.gameObject.transform.position.x > knight.transform.position.x)
            {
                collision.GetComponent<Rigidbody>().velocity = new Vector3(15f, 0f, 0f);
            }
        }

      }
    }

}
