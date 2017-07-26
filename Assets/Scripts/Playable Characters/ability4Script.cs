using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ability4Script : MonoBehaviour {
    public int AB4BonusATK;
    public float AB4KB;
    public string AB4Stun;
    public string AB4Ultimate;
    public GameObject knight;
    public GameObject ability4Icon;
    public bool ONCD;
    public bool check;
    public ParticleSystem effect;
    List <GameObject> currentCollisions = new List <GameObject> ();

    // Use this for initialization
    void Start ()
    {
        ability4Icon = FindObjectOfType<A4ONCD>().gameObject;
        AB4BonusATK = PlayerPrefs.GetInt("AB4BonusATK");
        AB4KB = PlayerPrefs.GetFloat("AB4KB");
        AB4Stun = PlayerPrefs.GetString("AB4Stun");
        AB4Ultimate = PlayerPrefs.GetString("AB4Ultimate");

        check = false;
        gameObject.GetComponent<Collider>().enabled = false;
        effect.Stop();
    }

    // Update is called once per frame
    void Update ()
    {
      if (knight.GetComponent<KnightStats>().UnlockAB4 == 0)
      {
        ability4Icon.SetActive(false);
      }
      else
      {
        ability4Icon.SetActive(true);
      }
      if (Input.GetKeyDown("4") && GetComponentInParent<KnightStats>().energy > 50 && ONCD == false)
      {
        effect.Play();
        gameObject.GetComponent<Collider>().enabled = true;
        check = !check;
        knight.GetComponent<KnightStats>().energy = knight.GetComponent<KnightStats>().energy - 50;
      }
      else if(Input.GetKeyUp("4")  && ONCD == false)
      {
        gameObject.GetComponent<Collider>().enabled = false;
        effect.Stop();
        StartCoroutine(Ability4onCD());
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
              if (gObject == null)
              {

              }
              else if(AB4Ultimate=="enabled" && gObject!= null)
              {
                  gObject.GetComponent<MonsterInterface>().hp = collision.gameObject.GetComponent<MonsterInterface>().hp - 1 - AB4BonusATK * knight.GetComponent<KnightStats>().AD;
                  if (knight.GetComponent<Player1Controls>().isFlippingLeft)
                  {
                      Debug.Log("1");
                      gObject.GetComponent<Rigidbody>().velocity += new Vector3(-knight.GetComponent<Player1Controls>().Ab1 * 25f - AB4KB, 0f, 0f);
                  }
                  if (knight.GetComponent<Player1Controls>().isFlippingRight)
                  {
                      Debug.Log("2");
                      gObject.GetComponent<Rigidbody>().velocity += new Vector3(knight.GetComponent<Player1Controls>().Ab1 * 25f + AB4KB, 0f, 0f);
                  }
              }
              else if (gObject != null)
                {
                    gObject.GetComponent<MonsterInterface>().hp = collision.gameObject.GetComponent<MonsterInterface>().hp - 1 - AB4BonusATK * knight.GetComponent<KnightStats>().AD;
                    if (knight.GetComponent<Player1Controls>().isFlippingLeft)
                    {
                        Debug.Log("1");
                        gObject.GetComponent<Rigidbody>().velocity += new Vector3(-knight.GetComponent<Player1Controls>().Ab1 * 25f - AB4KB, 0f, 0f);
                    }
                    if (knight.GetComponent<Player1Controls>().isFlippingRight)
                    {
                        Debug.Log("2");
                        gObject.GetComponent<Rigidbody>().velocity += new Vector3(knight.GetComponent<Player1Controls>().Ab1 *25f + AB4KB, 0f, 0f);
                    }
              }
            }
        }
    }
    private void OnTriggerExit (Collider collision)
    {
         currentCollisions.Remove(collision.gameObject);
     }
    IEnumerator Ability4onCD()
    {
        ONCD = true;
        ability4Icon.GetComponent<Image>().fillAmount = 0;
        ability4Icon.GetComponent<Image>().color = new Color32(128, 113, 113, 255);
        yield return new WaitForSeconds(5f);
        ability4Icon.GetComponent<Image>().color = Color.white;
        ONCD = false;

    }
}
