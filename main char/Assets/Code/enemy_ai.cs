using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_ai : MonoBehaviour
{
    #region public variables
    public Transform raycast;
    public LayerMask raycastlayermask;
    public float raycastlength;
    public float attackdistance;
    public float movespeed;
    public float timer;
    #endregion
    #region private variable
    private RaycastHit2D hit;
    private GameObject target;
    private Animator anim;
    private float distance;
    private bool attackmode;
    private bool inrange;
    private bool cooling;
    private float inttimer;
    #endregion
     void Awake()
    {
        inttimer = timer;
        anim= GetComponent<Animator>();

    }
    // Update is called once per frame
    void Update()
    {
        if (inrange)
        {
            hit = Physics2D.Raycast(raycast.position, Vector2.left, raycastlength, raycastlayermask);
            raycastdebugger();
        }
        if(hit.collider != null)
        {
            Enemylogic();
        }
        else if (hit.collider == null)
        {
            inrange = false;
        }
        if (inrange== false)
        {
            anim.SetBool("walking", false);
            stopattack();
        }
    }
    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "player")
        {
            target = trigger.gameObject;
            inrange = true;
        }
    }
    void Enemylogic()
    {
        distance= Vector2.Distance(transform.position,target.transform.position);
        if (distance > attackdistance){
            move();
            stopattack();
        }
        if (attackdistance >= distance && cooling==false)
        {
            attack();
        }
        if (cooling)
        {
            anim.SetBool("attack", false);
        }
    }
    void move()
    {
        anim.SetBool("walking", true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            Vector2 targetpositon = new Vector2(target.transform.position.x ,target.transform.position.y);
            transform.position= Vector2.MoveTowards(transform.position,targetpositon,movespeed* Time.deltaTime);
        }
    }
    void attack()
    {
        timer = inttimer;
        attackmode = true;
        anim.SetBool("walking", false);
        anim.SetBool("attack", true);
    } 
    void stopattack()
    {
        cooling = false;
        attackmode=false;
        anim.SetBool("attack", false);
    }
    void raycastdebugger()
    {
        if (distance > attackdistance)
        {
            Debug.DrawRay(raycast.position, Vector2.left * raycastlength, Color.red);
            Debug.Log("co mau do ");
        }
        else if (attackdistance> distance)
        {
            Debug.DrawRay(raycast.position, Vector2.left * raycastlength, Color.green);
            Debug.Log("co mau xanh ");
        }
    }
}
