using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ability4Script : MonoBehaviour {

  public GameObject knight;
  bool check;

    // Use this for initialization
    void Start ()
    {
        check = false;
    }

    // Update is called once per frame
    void Update ()
    {
      if(Input.GetKeyDown("4") && GetComponentInParent<KnightStats>().energy > 50)
      {
        check = !check;
      }
    }

    private void OnTriggerStay(Collider collision)
    {

      if(check && knight.GetComponent<KnightStats>().energy >50 && collision.gameObject.GetComponent<MonsterInterface>() != null)
      {
            collision.gameObject.GetComponent<MonsterInterface>().hp = collision.gameObject.GetComponent<MonsterInterface>().hp -knight.GetComponent<KnightStats>().AD*3;
            if (knight.GetComponent<Player1Controls>().isFlippingLeft)
            {
                collision.GetComponent<Rigidbody>().velocity += new Vector3(-knight.GetComponent<Player1Controls>().Ab1*30f, 0f, 0f);
            }
            if (knight.GetComponent<Player1Controls>().isFlippingRight)
            {
                collision.GetComponent<Rigidbody>().velocity += new Vector3(knight.GetComponent<Player1Controls>().Ab1 * 30f, 0f, 0f);
            }
            check = false;
      }
    }

    private void OnCollisionExit(Collision collision)
    {

    }

}
