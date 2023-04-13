using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IzquierdaPared : MonoBehaviour
{

    public bool ParedIzquierda = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Tilepmap")
        {
            ParedIzquierda = true;
        }
    }
}
