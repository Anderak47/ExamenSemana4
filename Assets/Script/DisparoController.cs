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
        Destroy(gameObject, 5f);
    }
    void Update()
    {

        rb.velocity = transform.right * velocity1;
        Destroy(gameObject, 5f);

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag== "DeadZombie")
        {
            Debug.Log("Entro trigger");
            Destroy(this.gameObject);
        }
    }

}
