using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_hp : MonoBehaviour
{
    public Sprite[] hpLeft;
    public GameObject npc;
    public SpriteRenderer currentHp;
    public MonsterInterface stats;
    // Use this for initialization
    void Start()
    {
        npc = transform.parent.GetComponentInChildren<MonsterInterface>().gameObject;
        stats = npc.GetComponent<MonsterInterface>();
    }
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(stats.hp >=1)
        currentHp.sprite = hpLeft[stats.hp];
        if(stats.hp<1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
