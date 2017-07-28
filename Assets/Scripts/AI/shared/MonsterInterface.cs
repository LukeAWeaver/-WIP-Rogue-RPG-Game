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
    public GameObject player;
    public bool inSight;
    public weaponReward wr;
    public bool isBurning; //used for ability 1 ultimate
    public bool exitBurningRadius;
    // Use this for initialization
    void Start()
    {
        exitBurningRadius = true;
        isFlippingRight = false;
        isFlippingLeft = false;
        rotationSpeed = 5.0f;
        isBurning = true;
    }
    private void Awake()
    {
        player = FindObjectOfType<KnightStats>().gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            if (gameObject.name == "mage")
            {
                gameObject.GetComponentInParent<Transform>().localScale = new Vector3(1f, 1f, 1f);
                reward = Resources.Load("WeaponPickUp") as GameObject;
            }
            else
            {
                reward = Resources.Load("Coins") as GameObject;
            }
            var gold = Instantiate(reward, transform.position, transform.rotation);
            Destroy(transform.parent.gameObject);
        }
        if (!exitBurningRadius)
        {
            if (isBurning)
            {
                StartCoroutine(DOT());
            }
            else if (!isBurning)
            {
                StopCoroutine(DOT());
            }
        }
        else
        {
            StopCoroutine(DOT());
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
    IEnumerator DOT()
    {
        if (isBurning)
        {
            isBurning = false;
            hp--;
            yield return new WaitForSeconds(1f);
            isBurning = true;
        }
    }
}
