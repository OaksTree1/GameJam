using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float MovementSpeed = 1.5f;

    public Rigidbody2D rigidBody;
    public Animator animator;
    public int Speed;
    float xScale;

    Vector2 Movement;

     void Start()
    {
        animator = GetComponent<Animator>();
        xScale = this.gameObject.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");
    }

     void FixedUpdate()
    {
        animator.SetInteger("Speed", Speed);
        rigidBody.MovePosition(rigidBody.position + Movement * MovementSpeed * Time.fixedDeltaTime);
        if(Input.anyKey)
        {
            Speed = 1;
        }
        if(!Input.anyKey)
        {
            Speed = 0;
        }

        if(Movement.x < 0)
        {
            this.gameObject.transform.localScale = new Vector2(-xScale, transform.localScale.y);

        }
        if(Movement.x > 0)
        {
            this.gameObject.transform.localScale = new Vector2(xScale, transform.localScale.y);
        }
    }
}
