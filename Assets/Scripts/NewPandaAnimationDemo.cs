using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPandaAnimationDemo : MonoBehaviour
{
    public float speed;

    Animator anim;
    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", rb.velocity.x);

        if (Input.GetKeyDown("a"))
            rb.velocity = Vector2.left * speed;

        if (Input.GetKeyUp("a"))
            rb.velocity = new Vector2(0,0);

        if (Input.GetKeyDown("d"))
            rb.velocity = Vector2.right * speed;

        if (Input.GetKeyUp("d"))
            rb.velocity = new Vector2(0, 0);

        if (Input.GetKey("w"))
            anim.SetBool("Happy", true);

        if (Input.GetKey("s"))
            anim.SetBool("Happy", false);
    }
}
