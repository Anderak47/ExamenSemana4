using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DerechaPared : MonoBehaviour
{
    public bool SaltarPared = false;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Tilepmap")
        {
            SaltarPared = true;
        }
    }

}
