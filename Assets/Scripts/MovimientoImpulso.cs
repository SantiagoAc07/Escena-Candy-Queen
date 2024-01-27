using UnityEngine;
using UnityEngine.UI;

public class MovimientoImpulso : MonoBehaviour
{
    MovimientoDireccion movimientoDireccion;
    public Image imagen;
    public float speed = 0.20f;
    private bool isIncreasing = true;

    public int contador;  //Codigo santi contador
    public bool presX = false;

    void awake()
    {
        movimientoDireccion = GetComponent<MovimientoDireccion>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(MovimientoDireccion.direccion)
        // {
        if (imagen.fillAmount >= 1f)
            isIncreasing = false;

        if (imagen.fillAmount <= 0f)
            isIncreasing = true;


        if (isIncreasing)
            imagen.fillAmount += speed * Time.deltaTime;
        else
            imagen.fillAmount -= speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            float captureImpulse = imagen.fillAmount;
            Debug.Log("Imagen Fill Amount Value; " + captureImpulse);
        }
        // while (presX == false)
        // {
        //     if (Input.GetKeyDown(KeyCode.X))
        //     {                       

        //     impulso();
        //     presX = true;
        //     } 

        //     if (contador<100)
        //     {
        //         contador+=20;
        //     }
        //     else if(contador == 100 && contador <=0 )
        //     {
        //         contador -=20;

        //     } 
        //     print(contador); 
        // }

        // }
    }

    void impulso()
    {
        Vector3 direccion = movimientoDireccion.CalcularVector();
        print(direccion);
        movimientoDireccion.centerOfMass.GetComponent<Rigidbody>().AddForce(direccion * 10f, ForceMode.Impulse);
    }
}
