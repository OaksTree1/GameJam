using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform PlayerTrans;
    Animator Animator;
    private bool Attack;


    int MoveSpeed = 4;
    int MaxDistance = 7;
    int MinDistance = 3;


    void Start()
    {
        Animator = GetComponent<Animator>();
        Attack = false;
    }

    void Update()
    {

        Animator.SetBool("Attack", Attack);

        transform.right = PlayerTrans.position - transform.position;


        if (Vector2.Distance(transform.position, PlayerTrans.position) > MinDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerTrans.position, MoveSpeed * Time.deltaTime);
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("RoadRed") as Sprite;
            
        }
        if (Vector2.Distance(transform.position, PlayerTrans.position) <= MaxDistance)
        {
            Attack = false;
        }
    }

    public void LookAt2D(Transform trans, Vector2 Target)
    {
        Vector2 currentvector = trans.position;
        var Direction = Target - currentvector;

        var AngleofAngles = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
        trans.rotation = Quaternion.AngleAxis(AngleofAngles, Vector3.forward);
    }

}
