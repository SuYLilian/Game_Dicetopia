using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexManergy : MonoBehaviour
{
    public float Speed;
    public float SpeedNum;

    //public Animator animator,animator2;

    private void Start()
    {
        //animator.Play("CloseUp");
       // animator2.Play("CloseUp");

    }

    private void Update()
    {

            Move();
            turnDir();

        

    }

    void Move()
    {
        transform.position += Vector3.right * Speed*Time.deltaTime;
    }

    void turnDir()
    {
        if (transform.position.x < -3.41f )
        {
            Speed = SpeedNum;
        }

        else if (transform.position.x > 3.21f )
        {
            Speed = SpeedNum*-1 ;
        }

    }
}
