using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
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
        runAnimator.SetBool("RunBool", false);

        if (Input.GetKeyDown(KeyCode.Space))
            swordAnimator.SetTrigger("AttackTrig");
        if (Input.GetKey(KeyCode.A))
        {
            runAnimator.SetBool("RunBool",true);
            transform.Translate(Vector2.left * .1f);
            transform.localScale = new Vector2(1, 1);

        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * .1f);
            runAnimator.SetBool("RunBool", true);
            transform.localScale = new Vector2(-1, 1);
        }

    }
}
