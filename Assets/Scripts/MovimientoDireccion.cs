using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimientoDireccion : MonoBehaviour


{
    [SerializeField] private Rigidbody playerRB;
    [SerializeField] private float fuerza;
    MovimientoImpulso movimientoImpulso;
    public Image medidorFuerza;
    public Transform centerOfMass;
    public float orbitalSpeed;
    public int estado = 0;
    private Vector3 dir;
    private float fuerzaCalculada;

    [SerializeField] Rigidbody rb;

    public static bool direccion;

    void Start(){

        rb = GetComponent<Rigidbody>();
    } 

    // Update is called once per frame
    void Update()
    {
        movimientoImpulso = GetComponent<MovimientoImpulso>();

        Orbit();
        if (Input.GetKeyDown(KeyCode.X))
        {
             if(estado == 0)
            {
                CalcularVector();
                estado++;
            }
             else if(estado == 1)
            {
                Impulsar();
            }
        }
    }

    public void CalcularVector()
    {
        //detiene la orbita de la flecha de direccion
        orbitalSpeed = 0f;

        //calcula el vector de direccion
        dir = (transform.position - centerOfMass.position).normalized;
        
        //return dir;
        //le da impulso en la direccion del vector dir
        //centerOfMass.GetComponent<Rigidbody>().AddForce(dir * 10f, ForceMode.Impulse);
    }

    public void Impulsar()
    {
        Debug.Log(gameObject.name + " - " + playerRB);
        playerRB.AddForce(dir * fuerza * medidorFuerza.fillAmount);
        orbitalSpeed = 150;
        estado = 0;
    }

    void Orbit()
    {
        transform.RotateAround(centerOfMass.position, Vector3.up, orbitalSpeed * Time.deltaTime);
        direccion = true;
    }

    
}
