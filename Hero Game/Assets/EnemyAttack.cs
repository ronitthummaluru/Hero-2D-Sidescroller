using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    BoxCollider2D c;
    EnemyCollision e;
    Animator a;
    public GameObject hp;
    float attackDelay = 0;
    bool attack = false;
    
    void Start()
    {
        c = GetComponent<BoxCollider2D>();
        hp = GetComponent<GameObject>();
        a = GameObject.Find("Ninja1").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            attack = true;
        }
        if (attack)
        {
            attackDelay += Time.deltaTime;
            if (attackDelay > .5)
            {
                c.isTrigger = false;
                attack = false;
                attackDelay = 0;
            }
        }
        

    }

    public void setTrigger(bool b)
    {
        c.isTrigger = b;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("BoNK");
        if (collision.gameObject.name.Contains("Ogre1") && attack)
        {
            e = collision.gameObject.GetComponent<EnemyCollision>();
            e.fallApart(transform.parent.parent.parent.parent.localScale * -1);
            

        }
    }
}

