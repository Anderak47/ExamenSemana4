using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonedaController : MonoBehaviour
{
     public GameManager gameManager;
    //public GameObject gameManager;
    void Start()
    {
       
    }
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            Debug.Log("cojio moneda");
            NumeroMonedas();
            Destroy(this.gameObject);
        }
    }
    private void NumeroMonedas()
    {
        var gm = gameManager.GetComponent<GameManager>();
        var uim = gameManager.GetComponent<UIManager>();
        gm.GanarMonedas();
        uim.PrintMonedas(gm.GetMonedas());
        //si coje 3 monedas le da 1 vida al jugador
        if (gm.GetMonedas() == 3)
        {
            gm.GanarVida();
            uim.PrinteVidasPersonaje(gm.GetVidasJugador());
        }
    }
}
