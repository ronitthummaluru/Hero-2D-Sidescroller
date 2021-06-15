using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    Animator animator;
    public Animator ninjaAnimator;
    public GameObject ninja;
    bool timeBool;
    float time;
    bool runB=true;
    bool colide = false;
    bool fallApart = false;
    int stop = 0;
    bool decreaseHealth = true;
    float health = 1.0f;
   public GameObject Leg_L;
    public GameObject Leg_R;
    public GameObject Head;
    public GameObject Arm_L;
    public GameObject Arm_R;
    public GameObject Sword;
    public GameObject Shield;
    public GameObject hp;
    public GameObject Body;
    // Start is called before the first frame update
    void Start()
    {
        ninja = GameObject.Find("Ninja1");
        ninjaAnimator = ninja.GetComponent<Animator>();
        animator = GetComponent<Animator>();
      
    }
    // Update is called once per frame
    void Update()
    {

        if (timeBool)
        {
            time += Time.deltaTime;
        }
        if (time > 5)
        {
            timeBool = false;
            time = 0;
            Destroy(Leg_L);
            Destroy(Leg_R);
            Destroy(Body);
            Destroy(Head);
            Destroy(Arm_R);
            Destroy(Arm_L);
            Destroy(Sword);
            Destroy(Shield);
            Destroy(gameObject);
        }
        if (fallApart)
        {
            Destroy(transform.GetChild(2).gameObject);
            animator.enabled = false;
            Destroy(hp);
            Vector2 v = new Vector2(-10*ninja.transform.localScale.x,-5);
            Leg_L.transform.parent = null;
            Leg_L.AddComponent<Rigidbody2D>();
            Leg_L.GetComponent<Rigidbody2D>().AddForce(v, ForceMode2D.Impulse);
            Leg_L.GetComponent<BoxCollider2D>().isTrigger = false;
            Leg_R.transform.parent = null;
            Leg_R.AddComponent<Rigidbody2D>();
            Leg_R.GetComponent<Rigidbody2D>().AddForce(v , ForceMode2D.Impulse);
            Leg_R.GetComponent<BoxCollider2D>().isTrigger = false;
            Arm_R.transform.parent = null;
            Arm_R.AddComponent<Rigidbody2D>();
            Arm_R.GetComponent<Rigidbody2D>().AddForce(v , ForceMode2D.Impulse);
            Arm_R.GetComponent<BoxCollider2D>().isTrigger = false;
            Arm_L.transform.parent = null;
            Arm_L.AddComponent<Rigidbody2D>();
            Arm_L.GetComponent<Rigidbody2D>().AddForce(v, ForceMode2D.Impulse);
            Arm_L.GetComponent<BoxCollider2D>().isTrigger = false;
            Head.transform.parent = null;
            Head.AddComponent<Rigidbody2D>();
            Head.GetComponent<Rigidbody2D>().AddForce(v , ForceMode2D.Impulse);
            Head.GetComponent<BoxCollider2D>().isTrigger = false;
            Sword.transform.parent = null;
            Sword.AddComponent<Rigidbody2D>();
            Sword.GetComponent<Rigidbody2D>().AddForce(v, ForceMode2D.Impulse);
            Sword.GetComponent<CircleCollider2D>().isTrigger = false;
            Shield.transform.parent = null;
            Shield.AddComponent<Rigidbody2D>();
            Shield.GetComponent<Rigidbody2D>().AddForce(v , ForceMode2D.Impulse);
            Shield.GetComponent<BoxCollider2D>().isTrigger = false;
            Body.transform.parent = null;
            Body.AddComponent<Rigidbody2D>();
            Body.GetComponent<Rigidbody2D>().AddForce(v, ForceMode2D.Impulse);
            Body.GetComponent<BoxCollider2D>().isTrigger = false;
            timeBool = true;
            fallApart = false;
        }
        if (colide && ninjaAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            if (!fallApart&&stop==0&&hp.transform.localScale.x<.1)
            {
                stop++;
                fallApart = true;
                animator.SetBool("RunBool", false);
                runB = false;
            }
            else
            {
                if (decreaseHealth)
                {
                    health -= .25f;
                    hp.transform.localScale = new Vector3(health * 2.1f, 1.01f, 1);
                    decreaseHealth = false;
                }
            }
        }
        else
        {
            decreaseHealth = true;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Ninja1"))
        {
            colide = true;
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Ninja1"))
        {
            colide = false;
        }
    }

    public bool getRunB()
    {
        return runB;
    }
}
