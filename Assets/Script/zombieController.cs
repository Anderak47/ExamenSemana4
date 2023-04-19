using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieController : MonoBehaviour
{
    SpriteRenderer sr;
    Animator animator;
    public float velocity = 0.9f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {

        rb.velocity = new Vector2(-velocity, 0);
        sr.flipX = true;

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("chocozombie");
            Time.timeScale = 0;

        }
    }
}
