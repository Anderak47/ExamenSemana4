using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabeza1Controller : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("-------");
        if (collision.CompareTag("Player"))
        {
            Debug.Log("entro");
        }
    }
}
