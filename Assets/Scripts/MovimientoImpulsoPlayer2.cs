using UnityEngine;
using UnityEngine.UI;


public class MovimientoImpulsoPlayer2 : MonoBehaviour
{
    public static MovimientoDireccion movDireccion;
    public Image imagen;
    public float speed = 0.40f;
    private bool isIncreasing = true;

    public int contador;  //Codigo santi contador
    public bool pressKey = false;

    void Awake()
    {
        movDireccion = GetComponent<MovimientoDireccion>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MovimientoDireccion.direccion)
        {
            if (imagen.fillAmount >= 1f)
                isIncreasing = false;

            if (imagen.fillAmount <= 0f)
                isIncreasing = true;


            if (isIncreasing)
                imagen.fillAmount += speed * Time.deltaTime;
            else
                imagen.fillAmount -= speed * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.M))
            {
                float captureImpulse = imagen.fillAmount;
                Debug.Log("Imagen Fill Amount Value; " + captureImpulse);
            }
        }

        void impulso()
        {
            //Vector3 direccion = movDireccion.CalcularVector();
            //print(direccion);
            //movDireccion.centerOfMass.GetComponent<Rigidbody>().AddForce(direccion * 10f, ForceMode.Impulse);
        }
    }

}