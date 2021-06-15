using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    Animator swordAnimator;
    // Start is called before the first frame update
    void Start()
    {
        swordAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            swordAnimator.SetTrigger("Attack");
    }
}
