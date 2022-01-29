using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{   //config
    public float walkspeed = 5f;
    Rigidbody2D myrig;
    Animator myani;
    //state
    bool isalive = true;
    
    // Start is called before the first frame update
    void Start()
    {
        myani = GetComponent<Animator>();
        myrig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        flipsprite();
    }
    public void Run()
    {
        float controlThrow = Input.GetAxis("Horizontal");
        Vector2 playervelocity = new Vector2(controlThrow*walkspeed,myrig.velocity.y);
        myrig.velocity = playervelocity;
        bool playerhorizontalspeed = Mathf.Abs(myrig.velocity.x) > Mathf.Epsilon;
        myani.SetBool("walking", playerhorizontalspeed);
    }
    public void flipsprite()
    {
        bool playerhorizontalspeed = Mathf.Abs(myrig.velocity.x) > Mathf.Epsilon;
        if (playerhorizontalspeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myrig.velocity.x), 1f);
        }

    }
}
