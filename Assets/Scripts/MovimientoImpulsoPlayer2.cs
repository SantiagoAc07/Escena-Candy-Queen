using UnityEngine;
using UnityEngine.UI;


public class MovimientoImpulsoPlayer2 : MonoBehaviour
{
    public static MovimientoDireccion movDireccion;

    public Image imagen; //Medidor de impulso (Visual)

    public float speed = 0.40f; //Velocidad del movimiento relativa  a la impulso

    private bool isIncreasing = true; //Verificador de impulso (Visual)

    public int contador;  //Contador

    public bool pressKey = false; //Verificador de tecla

    void Awake()
    {
        movDireccion = GetComponent<MovimientoDireccion>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MovimientoDireccion.direccion) //Activaciòn del medidor de impulso
        {
            if (imagen.fillAmount >= 1f) //Decrecimiento del impulso (Visual)
                isIncreasing = false;

            if (imagen.fillAmount <= 0f) //Aumento del impulso (Visual)
                isIncreasing = true;


            if (isIncreasing)
            {
                imagen.fillAmount += speed * Time.deltaTime; //Crecimiento de la barra visual amigable con diferentes dispositivos
            }
            else
            {
                imagen.fillAmount -= speed * Time.deltaTime; //Decrecimiento de la barra visual amigable con diferentes dispositivos
            }


            if (Input.GetKeyDown(KeyCode.M))
            {
                float captureImpulse = imagen.fillAmount;
                Debug.Log("Imagen Fill Amount Value; " + captureImpulse); //Ingreso de la tecla para capturar el impulso
            }
        }

        void impulso() // se llama la función a ejecutar el impulso
        {
            //Vector3 direccion = movDireccion.CalcularVector();
            //print(direccion);
            //movDireccion.centerOfMass.GetComponent<Rigidbody>().AddForce(direccion * 10f, ForceMode.Impulse);
        }
    }

}