using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AI : MonoBehaviour
{
    public string flip;
    private GameObject player;
    public MonsterInterface ThisNPCStats;
    public GameObject ThisNPC;
    public float range;
    public int counter;
    public float xVelocity;
    public float yVelocity;
    public float sight;
    public bool mobMentality;
    private float x;
    public List<GameObject> fellowMobs = new List<GameObject>();


    // Use this for initialization
    void Start () {
        mobMentality = false; //this is used for groups of AI chasing player
        ThisNPC = gameObject;
        ThisNPCStats = gameObject.GetComponent<MonsterInterface>();
        player = FindObjectOfType<KnightStats>().gameObject;
        counter = 0;
        InvokeRepeating("movement", 0, .03f);
        ThisNPCStats.hp = 3;
        ThisNPCStats.ms = .25f;
        ThisNPCStats.rotationSpeed = 4f;
        x = Mathf.Abs(transform.localScale.x);
        sight = 3.5f;

    }
    
    void movement ()
    {
        var target = player.transform.position;
        var gp = ThisNPCStats.transform.position;
        range = Mathf.Abs(Mathf.Sqrt((target.x - gp.x)* (target.x - gp.x) + (target.z - gp.z)* (target.z - gp.z)));

        if( range < sight )
        {
            GetComponent<MonsterInterface>().inSight = true;
        }
        else if(range>sight && GetComponent<MonsterInterface>().inSight == true)
        {
            GetComponent<MonsterInterface>().inSight = false;
        }
        else
        {
            if (counter % 60 ==0)
            {
                xVelocity = Random.Range(-0.02f, 0.02f);
                if(xVelocity <0)
                {
                    ThisNPCStats.isFlippingLeft = true;
                    ThisNPCStats.isFlippingRight = false;
                }
                else
                {
                    ThisNPCStats.isFlippingLeft = false;
                    ThisNPCStats.isFlippingRight = true;
                }
                yVelocity = Random.Range(-0.02f, 0.02f);
            }
            transform.Translate(xVelocity, 0f, yVelocity);
            GetComponent<MonsterInterface>().inSight = false;
            counter++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(ThisNPCStats.hp <=0)
        {
            player.GetComponent<KnightStats>().exp++;
        }
        if(ThisNPCStats.hp == 1)
        {
            ThisNPCStats.ms = .2f;
        }
        var target = player.transform.position;
        if (GetComponent<MonsterInterface>().inSight)
        {
            if (transform.position.x > (target.x + .6f))
            {
                ThisNPCStats.isFlippingLeft = true;
                ThisNPCStats.isFlippingRight = false;
                if (GetComponent<Rigidbody>().velocity.x > -3f)
                    GetComponent<Rigidbody>().velocity += new Vector3(-ThisNPCStats.ms, 0f, 0f);
            }
            else if (transform.position.x < (target.x - .6f))
            {
                ThisNPCStats.isFlippingLeft = false;
                ThisNPCStats.isFlippingRight = true;
                if (GetComponent<Rigidbody>().velocity.x < 3f)
                    GetComponent<Rigidbody>().velocity += new Vector3(ThisNPCStats.ms, 0f, 0f);
            }
            if (transform.position.z > (target.z + .01f) && GetComponent<Rigidbody>().velocity.z > -3f)
            {
                GetComponent<Rigidbody>().velocity += new Vector3(0f, 0f, -ThisNPCStats.ms);
            }
            else if (transform.position.z < (target.z - .01f) && GetComponent<Rigidbody>().velocity.z < 3f)
            {
                GetComponent<Rigidbody>().velocity += new Vector3(0f, 0f, ThisNPCStats.ms);
            }
            sight = 7f;
        }
        else
        {
            sight = 3.5f;
        }
        ThisNPCStats.CheckFlipping();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<AI>() != null || collision.gameObject.GetComponent<archerAI>() != null)
        {
            fellowMobs.Add(collision.gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
            foreach (GameObject mob in fellowMobs)
            {
                if(mob == null)
                {
                }
                else if(GetComponent<MonsterInterface>().inSight)
                mob.GetComponent<MonsterInterface>().inSight = true;
            }
    }
    private void OnTriggerExit(Collider collision)
    {
        fellowMobs.Remove(collision.gameObject);
    }
}
