using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Combat : MonoBehaviour
{
    public Animator myanin;
    public Transform attackpoint;
    public float attackrange = 0.5f;
    public LayerMask enenylayer;
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
        Collider2D [] hitenemies = Physics2D.OverlapCircleAll(attackpoint.position, attackrange, enenylayer);
        foreach(Collider2D hit in hitenemies)
        {

        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackpoint.position, attackrange);
    }
}
