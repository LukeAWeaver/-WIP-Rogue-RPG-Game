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
        knight.GetComponent<KnightStats>().energy = knight.GetComponent<KnightStats>().energy - 50;
      }
    }

    private void OnTriggerStay(Collider collision)
    {

      if(check && knight.GetComponent<KnightStats>().energy >50 && collision.gameObject.GetComponent<MonsterInterface>() != null)
      {
            check = false;
            collision.gameObject.GetComponent<MonsterInterface>().hp = collision.gameObject.GetComponent<MonsterInterface>().hp -knight.GetComponent<KnightStats>().AD;
            if (knight.GetComponent<Player1Controls>().isFlippingLeft)
            {
              Debug.Log("1");

                collision.GetComponent<Rigidbody>().velocity += new Vector3(-knight.GetComponent<Player1Controls>().Ab1*30f, 0f, 0f);
            }
            if (knight.GetComponent<Player1Controls>().isFlippingRight)
            {
                Debug.Log("2");
                collision.GetComponent<Rigidbody>().velocity += new Vector3(knight.GetComponent<Player1Controls>().Ab1 * 30f, 0f, 0f);
            }
      }
    }

    private void OnCollisionExit(Collision collision)
    {

    }

}
