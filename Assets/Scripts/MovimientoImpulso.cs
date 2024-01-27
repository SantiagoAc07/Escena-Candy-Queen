using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimientoImpulso : MonoBehaviour
{
    MovimientoDireccion movimientoDireccion;
    public Image imagen;
    private float vidaMaxima=100;

    // Update is called once per frame
    void Update()
    {
        movimientoDireccion = GetComponent<MovimientoDireccion>(); 

         if (Input.GetKeyDown(KeyCode.X))
         {
           movimientoDireccion. CalcularVector();
        //    vector();
            imagen.fillAmount = 25/vidaMaxima;
           
        }   
    }
     void vector()
     {
         Vector3 dir = (transform.position - movimientoDireccion.centerOfMass.position).normalized;
         movimientoDireccion.centerOfMass.GetComponent<Rigidbody>().AddForce(dir * 10f, ForceMode.Impulse);
     }
}
