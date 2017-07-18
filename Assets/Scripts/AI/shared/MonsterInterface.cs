using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterInterface : MonoBehaviour
{
    public int hp;
    public int energy;
    public float ms;
    public bool isFlippingLeft;
    public bool isFlippingRight;
    public GameObject reward;
    public float rotationSpeed;
    public int coinAmount;
    private GameObject player;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<KnightStats>().gameObject;
        isFlippingRight = false;
        isFlippingLeft = false;
        rotationSpeed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            var gold = Instantiate(reward, transform.position, transform.rotation);
            gold.transform.localScale = gold.transform.localScale * .4f;
            Destroy(transform.parent.gameObject);
        }
    }
    public void CheckFlipping()
    {
        //FLIPPING LEFT
        if (isFlippingLeft && transform.localScale.x > -.99f)
        {
            Vector3 rot = transform.localScale;
            rot.x = rot.x + -rotationSpeed * Time.deltaTime;
            transform.localScale = rot;

        }
        else if (isFlippingLeft && transform.localScale.x <= -1f)
        {
            Vector3 rot = transform.localScale;
            rot.x = -1f;
            transform.localScale = rot;
        }
        //FLIPPING RIGHT
        if (isFlippingRight && transform.localScale.x < .99f)
        {
            Vector3 rot = transform.localScale;
            rot.x = rot.x + rotationSpeed * Time.deltaTime;
            transform.localScale = rot;

        }
        else if (isFlippingRight && transform.localScale.x >= 1f)
        {
            Vector3 rot = transform.localScale;
            rot.x = 1f;
            transform.localScale = rot;
        }
    }

}
