using UnityEngine;
using UnityEngine.UI;

public class MovimientoImpulso2 : MonoBehaviour
{
    public static MovimientoDireccion2 movDirection;
    public Image imagen;
    public float speed = 0.40f;
    private bool isIncreasing;

    public int contador;  //Codigo santi contador
    public bool pressKey = false;

    void Start()
    {
        movDirection = GetComponent<MovimientoDireccion2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MovimientoDireccion2.direccion)
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
            //Vector3 direccion = movimientoDireccion.CalcularVector();
            //print(direccion);
            //movimientoDireccion.centerOfMass.GetComponent<Rigidbody>().AddForce(direccion * 10f, ForceMode.Impulse);
        }
    }

}