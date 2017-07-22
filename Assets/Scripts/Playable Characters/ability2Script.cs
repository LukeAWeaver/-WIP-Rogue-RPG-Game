using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ability2Script : MonoBehaviour {

    public GameObject knight;
    public GameObject ability2Icon;
    bool check;
    public ParticleSystem wave;
    public AudioClip sfx;
    private AudioSource source;
    private bool ab2OnCD;
    int currentHP;
    void Start ()
    {
        wave.Stop();
        gameObject.GetComponent<Collider>().enabled = false;
        check = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if (ability2Icon.GetComponent<Image>().fillAmount < 1)
        {
            ability2Icon.GetComponent<Image>().fillAmount = ability2Icon.GetComponent<Image>().fillAmount + .00125f;
        }
        wave.transform.localScale = new Vector3(1.5f + knight.GetComponent<KnightStats>().AB2Radius, 1.5f + knight.GetComponent<KnightStats>().AB2Radius, 1);

        if (Input.GetKeyDown("2") && GetComponentInParent<KnightStats>().energy > 20 && ab2OnCD == false)
      {
            StartCoroutine(ability2CD());
            gameObject.GetComponent<Collider>().enabled = true;
            check = !check;
            knight.GetComponent<KnightStats>().energy = knight.GetComponent<KnightStats>().energy - 20;
            wave.Play();
            source = GetComponent<AudioSource>();
            source.clip = sfx;
            source.Play();
            if (knight.GetComponent<KnightStats>().AB2Ultimate == 1) //ultimate unlocked
            {
                if (PlayerPrefs.GetInt("currentHP") == 11)
                {
                    currentHP = PlayerPrefs.GetInt("currentHP") + 1;
                }
                else if (PlayerPrefs.GetInt("currentHP") == 12)
                {
                    currentHP = PlayerPrefs.GetInt("currentHP");
                }
                else
                {
                    currentHP = PlayerPrefs.GetInt("currentHP") + 2;
                }
                PlayerPrefs.SetInt("currentHP", currentHP);

            }
        }
      else if(Input.GetKeyUp("2"))
      {
        gameObject.GetComponent<Collider>().enabled = false;
        wave.Stop();
      }
    }

    private void OnTriggerStay(Collider collision)
    {
      if(check && knight.GetComponent<KnightStats>().energy >20 && collision.gameObject.GetComponent<MonsterInterface>() != null)
      {
        check = false;
        collision.gameObject.GetComponent<MonsterInterface>().hp = collision.gameObject.GetComponent<MonsterInterface>().hp - 1 - knight.GetComponent<KnightStats>().AB2BonusATK;
        //Top
        if(collision.gameObject.transform.position.z > knight.transform.position.z && collision.gameObject.transform.position.x < knight.transform.position.x)
        {
            collision.GetComponent<Rigidbody>().velocity = new Vector3(-12f - knight.GetComponent<KnightStats>().AB2KB, 0f, 12f + knight.GetComponent<KnightStats>().AB2KB);
        }
        else if(collision.gameObject.transform.position.z > knight.transform.position.z && collision.gameObject.transform.position.x > knight.transform.position.x)
        {
            collision.GetComponent<Rigidbody>().velocity = new Vector3(12f + knight.GetComponent<KnightStats>().AB2KB, 0f, 12f + knight.GetComponent<KnightStats>().AB2KB);
        }
       else if(collision.gameObject.transform.position.z < knight.transform.position.z && collision.gameObject.transform.position.x < knight.transform.position.x)
        {
            collision.GetComponent<Rigidbody>().velocity = new Vector3(-12f - knight.GetComponent<KnightStats>().AB2KB, 0f, -12f - knight.GetComponent<KnightStats>().AB2KB);
        }
        else if(collision.gameObject.transform.position.z < knight.transform.position.z && collision.gameObject.transform.position.x > knight.transform.position.x)
        {
            collision.GetComponent<Rigidbody>().velocity = new Vector3(12f + knight.GetComponent<KnightStats>().AB2KB, 0f, -12f - knight.GetComponent<KnightStats>().AB2KB);
        }
      }
      else if(collision.gameObject.tag=="InteractableScenery")
        {
            collision.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, -10f - knight.GetComponent<KnightStats>().AB2KB);
            //Left
            if (collision.gameObject.transform.position.x < knight.transform.position.x)
            {
                collision.GetComponent<Rigidbody>().velocity = new Vector3(-10f - knight.GetComponent<KnightStats>().AB2KB, 0f, 0f);
            }
            //Right
            else if (collision.gameObject.transform.position.x > knight.transform.position.x)
            {
                collision.GetComponent<Rigidbody>().velocity = new Vector3(10f + knight.GetComponent<KnightStats>().AB2KB, 0f, 0f);
            }
        }
    }
    IEnumerator ability2CD()
    {
        ability2Icon.GetComponent<Image>().fillAmount = 0;
        ab2OnCD = true;
        ability2Icon.GetComponent<Image>().color = new Color32(128, 113, 113, 255);
        yield return new WaitForSeconds(8f);
        ability2Icon.GetComponent<Image>().color = Color.white;
        ab2OnCD = false;
    }
}
