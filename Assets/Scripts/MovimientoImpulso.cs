using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoImpulso : MonoBehaviour
{
    MovimientoDireccion movimientoDireccion;

    // Update is called once per frame
    void Update()
    {
        movimientoDireccion = GetComponent<MovimientoDireccion>(); 

         if (Input.GetKeyDown(KeyCode.X))
         {
           movimientoDireccion. CalcularVector();
           vector();
           
        }   
    }
     void vector()
     {
         Vector3 dir = (transform.position - movimientoDireccion.centerOfMass.position).normalized;
         movimientoDireccion.centerOfMass.GetComponent<Rigidbody>().AddForce(dir * 10f, ForceMode.Impulse);
     }
}
