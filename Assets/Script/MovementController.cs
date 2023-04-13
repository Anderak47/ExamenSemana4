using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public FootController footController;
    public float jumpForce = 400f;
    private Rigidbody2D rb;
    public IzquierdaPared izquierdaPared;
    public DerechaPared derechaPared;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && footController.CanJump())
        {
            rb.AddForce(transform.up * jumpForce);
            footController.Jump();
        }
      

    }
  
}
