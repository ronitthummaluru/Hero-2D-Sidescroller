using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAttack : MonoBehaviour
{
    Animator swordAnimator;
    Animator runAnimator;
    // Start is called before the first frame update
    void Start()
    {
        swordAnimator = GetComponent<Animator>();
        runAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            swordAnimator.SetTrigger("Attack");
        
        if (Input.GetKey(KeyCode.A))
        {
            runAnimator.SetTrigger("Run");
            transform.Translate(Vector2.left * .1f);
            transform.localScale = new Vector2(1,1);
            
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * .1f);
            runAnimator.SetTrigger("Run");
            transform.localScale = new Vector2(-1, 1);
        }
    }
}
