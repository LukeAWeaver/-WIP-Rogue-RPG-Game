using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ability4Script : MonoBehaviour {

  public GameObject knight;
  bool check;
  public ParticleSystem effectLeft;
  public ParticleSystem effectRight;
  List <GameObject> currentCollisions = new List <GameObject> ();

    // Use this for initialization
    void Start ()
    {
        check = false;
        gameObject.GetComponent<Collider>().enabled = false;
        effectLeft.Stop();
        effectRight.Stop();
    }

    // Update is called once per frame
    void Update ()
    {
      if(Input.GetKeyDown("4") && GetComponentInParent<KnightStats>().energy > 50)
      {
            gameObject.GetComponent<Collider>().enabled = true;
            check = !check;
        knight.GetComponent<KnightStats>().energy = knight.GetComponent<KnightStats>().energy - 50;

      }
      else if(Input.GetKeyUp("4"))
        {
            gameObject.GetComponent<Collider>().enabled = false;
            effectLeft.Stop();
            effectRight.Stop();
        }
    }
    private void OnTriggerEnter (Collider collision)
    {
      if(collision.gameObject.GetComponent<MonsterInterface>() != null)
      {
            currentCollisions.Add (collision.gameObject);
      }
    }
    private void OnTriggerStay(Collider collision)
    {

      if(check && knight.GetComponent<KnightStats>().energy >50 && collision.gameObject.GetComponent<MonsterInterface>() != null)
      {
            check = false;
            foreach (GameObject gObject in currentCollisions)
            {
              gObject.GetComponent<MonsterInterface>().hp = collision.gameObject.GetComponent<MonsterInterface>().hp -knight.GetComponent<KnightStats>().AD;
              if (knight.GetComponent<Player1Controls>().isFlippingLeft)
              {
                Debug.Log("1");

                  gObject.GetComponent<Rigidbody>().velocity += new Vector3(-knight.GetComponent<Player1Controls>().Ab1*30f, 0f, 0f);
                  effectLeft.Play();
              }
              if (knight.GetComponent<Player1Controls>().isFlippingRight)
              {
                  Debug.Log("2");
                  gObject.GetComponent<Rigidbody>().velocity += new Vector3(knight.GetComponent<Player1Controls>().Ab1 * 30f, 0f, 0f);
                  effectRight.Play();
              }
            }
        }
    }
    private void OnTriggerExit (Collider collision)
    {
      if(collision.gameObject.GetComponent<MonsterInterface>() != null)
      {
         currentCollisions.Remove(collision.gameObject);
      }
     }
}
