using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PersonajeController : MonoBehaviour
{
    //public FootController footController;
    Rigidbody2D rb;
    Animator animator;
    private int currentAnimation = 1;
    SpriteRenderer sr;
    public Cabeza1Controller controller;

    public GameObject Disparo;
    public float velocityX = 0.1f;

    public Transform PuntoBala;
    public GameObject MoventBala;

    public GameObject MoventBala2;
    public GameObject MoventBala3;

    //
    public GameObject MoventBalaPrefab;
  
    //
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        currentAnimation = 1;
        var velocityY = rb.velocity.y;
        rb.velocity = new Vector2(0, velocityY);

        //derecha
        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentAnimation = 2;
            rb.velocity = new Vector2(13, velocityY);
            sr.flipX = false;
        }
        //izquierda
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentAnimation = 2;
            rb.velocity = new Vector2(-13, velocityY);
            sr.flipX = true;

        }
        //al saltar el zombie corre mas
        if (Input.GetKey(KeyCode.RightArrow) && controller.zombieJump())
        {
            currentAnimation = 2;
            rb.velocity = new Vector2(30, velocityY);
            sr.flipX = false;
        }
        //correr
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.X))
        {
            currentAnimation = 2;
            rb.velocity = new Vector2(20, velocityY);
            sr.flipX = false;

        }
        //al saltar el zombie corre mas
        if (Input.GetKey(KeyCode.LeftArrow) && controller.zombieJump())
        {
            currentAnimation = 2;
            rb.velocity = new Vector2(-30, velocityY);
            sr.flipX = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.X))
        {
            currentAnimation = 2;
            rb.velocity = new Vector2(-20, velocityY);
            sr.flipX = true;

        }
        //deslizar
        if (Input.GetKey(KeyCode.D))
        {
            bool verificar = sr.flipX;

            if (verificar == true && Input.GetKey(KeyCode.D))
            {
                currentAnimation = 4;
                rb.velocity = new Vector2(-5, velocityY);
            }
            if (verificar == false && Input.GetKey(KeyCode.D))
            {
                currentAnimation = 4;
                rb.velocity = new Vector2(5, velocityY);
            }
        }
        //ataque
        if (Input.GetKey(KeyCode.B))
        {
            currentAnimation = 5;
            rb.velocity = new Vector2(0, velocityY);

        }
        //TIRAR
        if (Input.GetKey(KeyCode.T))
        {
            currentAnimation = 3;
            rb.velocity = new Vector2(0, velocityY);
        }
        //muerte
        if (Input.GetKey(KeyCode.M))
        {
            currentAnimation = 6;
            rb.velocity = new Vector2(0, velocityY);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            currentAnimation = 3;
            var currentPosition = transform.position;
            var position = new Vector3(currentPosition.x - 2, currentPosition.y, 10);
            var balaGO = Instantiate(MoventBalaPrefab, PuntoBala.position, Quaternion.identity);
            var controller = balaGO.GetComponent<MoventBalaController>();
            controller.velocidad = 10f;
            MoventBala = balaGO;

        }
        if (Input.GetKeyDown(KeyCode.Z) && MoventBala != null)
        {
            currentAnimation = 3;
            // Instanciamos la primera bala en su posición actual
            var balaGO = Instantiate(MoventBala, MoventBala.transform.position, Quaternion.identity);
            var controller = balaGO.GetComponent<MoventBalaController>();
            controller.velocidad = 10f;
            controller.velocidadY = 0f;

            // Instanciamos la segunda bala en la posición de la primera bala, con una ligera desviación hacia arriba
            var bala2 = Instantiate(MoventBala2, MoventBala.transform.position + new Vector3(0.5f, 0.5f, 0f), Quaternion.identity);
            var controller2 = bala2.GetComponent<MoventBalaController>();
            controller2.velocidad = 10f;
            controller2.velocidadY = 5f;

            // Instanciamos la tercera bala en la posición de la primera bala, con una ligera desviación hacia abajo
            var bala3 = Instantiate(MoventBala3, MoventBala.transform.position + new Vector3(0.5f, -0.5f, 0f), Quaternion.identity);
            var controller3 = bala3.GetComponent<MoventBalaController>();
            controller3.velocidad = 10f;
            controller3.velocidadY = -5f;
            Destroy(MoventBala, 5f);
            Destroy(balaGO, 5f);
            Destroy(bala2, 5f);
            Destroy(bala3, 5f);
            MoventBala = null;
        }
        animator.SetInteger("Estado", currentAnimation);
    }
}
