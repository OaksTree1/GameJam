using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScenePlayer : MonoBehaviour
{

    Animator animator;
    public AudioClip Clip;
    Rigidbody2D rigidBody;
    public AudioSource Audio;
    SpriteRenderer spriteRenderer;
    public bool Stop;
    public int Speed;
    public float Xspeed;
    public float Yspeed;
   
    [HideInInspector]
    public StopPlayer stopPlayer;
    public Collision2D colliderTwoD;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
        Stop = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animator.SetInteger("Speed", Speed);
        if (!Stop)
        {
            rigidBody.velocity = new Vector2(Xspeed, Yspeed);
            Speed = 1;
            Audio.PlayOneShot(Clip);
        }
        if(Stop)
        {
            Speed = 0;
            Audio.Pause();
        }
        stopPlayer.OnCollisionEnter2D(colliderTwoD);
    }
}
