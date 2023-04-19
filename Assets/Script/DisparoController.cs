using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocity1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.velocity = new Vector2(+velocity1,0);
        Destroy(gameObject, 5f);
    }
}
