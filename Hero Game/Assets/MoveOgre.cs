using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOgre : MonoBehaviour
{
    float time;
    float timeBetweenChanges = 8.0f;
    public Animator animator;
    bool runB = true;
    bool apart = false;
    public GameObject body, hand_l, hand_r, head, skirt, leg_l, leg_r;
    // Start is called before the first frame update
    void Start()
    {
        //enemyAttack = GetComponent<EnemyAttack>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!apart)
        {
            time += Time.deltaTime;

            if (time < timeBetweenChanges)
            {
                transform.localScale = new Vector2(1, 1);

                transform.Translate(Vector3.left * .025f);
            }

            else if (time >= timeBetweenChanges && time < 2 * timeBetweenChanges)
            {
                transform.localScale = new Vector2(-1, 1);
                transform.Translate(Vector3.right * .025f);
            }
            else if (time >= 2 * timeBetweenChanges)
                time = 0;
        }
    }

    public void fallApart(Vector3 v)
    {
        if (!apart)
        {
            v *= -10;
            Vector3 p = new Vector3(0, -10, -10);
            animator.SetBool("DeathAni", true);
            animator.SetBool("Idle", true);

            animator.enabled = false;

            body.transform.parent = null;
            body.AddComponent<Rigidbody2D>();
            body.GetComponent<Rigidbody2D>().AddForce(v + p, ForceMode2D.Impulse);
            body.GetComponent<BoxCollider2D>().isTrigger = false;
            hand_l.transform.parent = null;
            hand_l.AddComponent<Rigidbody2D>();
            hand_l.GetComponent<Rigidbody2D>().AddForce(v + p, ForceMode2D.Impulse);
            hand_l.GetComponent<BoxCollider2D>().isTrigger = false;
            hand_r.transform.parent = null;
            hand_r.AddComponent<Rigidbody2D>();
            hand_r.GetComponent<Rigidbody2D>().AddForce(v + p, ForceMode2D.Impulse);
            hand_r.GetComponent<BoxCollider2D>().isTrigger = false;
            head.transform.parent = null;
            head.AddComponent<Rigidbody2D>();
            head.GetComponent<Rigidbody2D>().AddForce(v + p, ForceMode2D.Impulse);
            head.GetComponent<BoxCollider2D>().isTrigger = false;
            skirt.transform.parent = null;
            skirt.AddComponent<Rigidbody2D>();
            skirt.GetComponent<Rigidbody2D>().AddForce(v + p, ForceMode2D.Impulse);
            skirt.GetComponent<BoxCollider2D>().isTrigger = false;
            leg_l.transform.parent = null;
            leg_l.AddComponent<Rigidbody2D>();
            leg_l.GetComponent<Rigidbody2D>().AddForce(v + p, ForceMode2D.Impulse);
            leg_l.GetComponent<BoxCollider2D>().isTrigger = false;
            leg_r.transform.parent = null;
            leg_r.AddComponent<Rigidbody2D>();
            leg_r.GetComponent<Rigidbody2D>().AddForce(v + p, ForceMode2D.Impulse);
            leg_r.GetComponent<BoxCollider2D>().isTrigger = false;
            apart = true;
        }

         

    }

}
