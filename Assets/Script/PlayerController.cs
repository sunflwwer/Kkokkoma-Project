using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rigid;

    bool isGround = false;
    Vector3 moveVector;
    public float gravity;
    public float force;

    public bool canDouble;

    private void OnGravity()
    {

        if (rigid.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            if (gravity > 0)
            {

                gravity = 0;
                isGround = true;
                canDouble = true;

            }
            
        }
        else
        {

            gravity += 0.05f + Time.deltaTime;
            isGround = false;

        }

        if (gravity > 20f) gravity = 20f;

    }

    private void Jump()
    {
        if (isGround)
        {

            if (Input.GetButtonDown("Jump"))
            {
                gravity = -force;
                isGround = false;
            }

        }
        else if (canDouble)
        {

            if (Input.GetButtonDown("Jump"))
            {
                gravity = -force;
                isGround = false;
                canDouble = false;
            }

        }
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        OnGravity();
        Jump();

        moveVector.x = Input.GetAxisRaw("Horizontal") * 3;
        moveVector.y = -gravity;
        rigid.velocity = moveVector;

    }

}
