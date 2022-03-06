using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Combat : MonoBehaviour
{
    public Animator myanin;
    public Transform attackpoint;
    public float attackrange = 0.5f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }
    void Attack()
    {
        myanin.SetTrigger("defend");
    }
}
