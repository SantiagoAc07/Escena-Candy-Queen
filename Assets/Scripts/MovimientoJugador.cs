using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public Transform centerOfMass;
    public float orbitalSpeed;
    public float scale = 1.0f;

    // Update is called once per frame

    
    void Update(){        
        if(Input.GetKeyDown(KeyCode.X))
            CalcularVector(); //llama una funcion con la cual se calcula el vector de direccion
        Orbit();

        

    }

    private void CalcularVector(){
        //detiene la orbita de la flecha de direccion
        orbitalSpeed = 0;

        //calcula el vector de direccion
        Vector3 dir = (transform.position - centerOfMass.position).normalized;

        //le da impulso en la direccion del vector dir aqui cambiaras el 5f por la fuerza que vas a implementar
        centerOfMass.GetComponent<Rigidbody>().AddForce(dir * 5f, ForceMode.Impulse);
    }

    //orbita donde se hace el movimiento de nuestro indicador
    void Orbit(){

        transform.RotateAround(centerOfMass.position, Vector3.up, orbitalSpeed * Time.deltaTime);
        
    }

   
}