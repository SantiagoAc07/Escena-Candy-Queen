using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDireccion : MonoBehaviour
{
    MovimientoImpulso movimientoImpulso;
    public Transform centerOfMass;
    public float orbitalSpeed;

    // Update is called once per frame
    void Update()
    {
        movimientoImpulso = GetComponent<MovimientoImpulso>();

        Orbit();
        // if (Input.GetKeyDown(KeyCode.X))
        // {
        //     CalcularVector();
        // }
    }

    public void CalcularVector()
    {
        //detiene la orbita de la flecha de direccion
        orbitalSpeed = 0f;

        //calcula el vector de direccion
        Vector3 dir = (transform.position - centerOfMass.position).normalized;


        //le da impulso en la direccion del vector dir
        //centerOfMass.GetComponent<Rigidbody>().AddForce(dir * 10f, ForceMode.Impulse);
    }

    void Orbit()
    {
        transform.RotateAround(centerOfMass.position, Vector3.up, orbitalSpeed * Time.deltaTime);
    }
}
