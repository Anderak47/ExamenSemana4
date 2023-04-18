using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public FootController footController;
    public float jumpForce = 400f;
    private Rigidbody2D rb;
    public LateralesController lateralesController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        //if (Input.GetKeyUp(KeyCode.Space) && footController.CanJump())
        //{
        //    rb.AddForce(transform.up * jumpForce);
        //    footController.Jump();
        //}
        bool goJump = (footController.canJump && !lateralesController.nextJump()) || (footController.canJump && lateralesController.nextJump()) || (!footController.canJump && lateralesController.nextJump());

        if (Input.GetKeyDown(KeyCode.Space) && goJump)
        {
            this.impulseAdd(this.jumpForce);

        }
    }
    private void impulseAdd(float jumpForce)
    {
        rb.AddForce(new Vector2(0, jumpForce));
        footController.canJump = false;
        lateralesController.validationJump();
    }

}
