using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurAI : MonoBehaviour
{
    public bool inSight;
    private GameObject player;
    public MonsterInterface ThisNPCStats;
    public float range;
    private bool onCD;
    private bool canTakeDamage;
    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<MonsterInterface>().hp = 12;
        player = FindObjectOfType<KnightStats>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        ThisNPCStats = gameObject.GetComponent<MonsterInterface>();

        var target = player.transform.position;
        var minoPos = ThisNPCStats.transform.position;

        range = Mathf.Sqrt((target.x - minoPos.x) * (target.x - minoPos.x) + (target.z - minoPos.z) * (target.z - minoPos.z));

        if (range < 8)
        {
            inSight = true;
        }
        else
        {
            inSight = false;
        }
        if (inSight && range > 5 && onCD==false)
        {
            StartCoroutine(chargeONCD());
            StartCoroutine(charge());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "TreeMino")
        {
            StartCoroutine(stunned());
        }
        if (canTakeDamage)
        {

        }
    }
    IEnumerator charge()
    {
        var target = player.transform.position;
        gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        yield return new WaitForSeconds(2f);
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position,target,5f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(2f);
        StartCoroutine(knockback());

    }
    IEnumerator knockback()
    {
        if (range < 3)
        {
            var minoPos = ThisNPCStats.transform.position;
            if (minoPos.z < player.transform.position.z && minoPos.x > player.transform.position.x)
            {
                player.GetComponent<Rigidbody>().velocity = new Vector3(-20f, 0f, 20f);
            }
            else if (minoPos.z < player.transform.position.z && minoPos.x < player.transform.position.x)
            {
                player.GetComponent<Rigidbody>().velocity = new Vector3(20f, 0f, 20f);
            }
            else if (minoPos.z > player.transform.position.z && minoPos.x > player.transform.position.x)
            {
                player.GetComponent<Rigidbody>().velocity = new Vector3(-20f, 0f, -20f);
            }
            else if (minoPos.z > player.transform.position.z && minoPos.x < player.transform.position.x)
            {
                player.GetComponent<Rigidbody>().velocity = new Vector3(20f, 0f, -20f);
            }
            yield return new WaitForSeconds(1f);
        }
    }
    IEnumerator stunned()
    {
        canTakeDamage = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(5f);
        canTakeDamage = false;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        StartCoroutine(knockback());
    }
    IEnumerator chargeONCD()
    {
        onCD = true;
        yield return new WaitForSeconds(8f);
        onCD = false;
    }
}
