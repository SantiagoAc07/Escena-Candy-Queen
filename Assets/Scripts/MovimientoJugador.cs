using UnityEngine;
using UnityEngine.UI;

public class MovimientoJugador : MonoBehaviour
{
    public Transform centerOfMass;
    public float orbitalSpeed;
    public float scale = 1.0f;

    public Image force;

    // Barra de fuerza
    public RectTransform barraFuerza;

    // Valor del campo "Fill amount"
    public float fillAmount;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            barra();// Detiene el ciclo
        }
        else
        {
            // Aumenta el valor del campo "Fill amount"
            fillAmount += Time.deltaTime;

            // Si el valor del campo "Fill amount" es mayor que 100
            if (fillAmount > 100f)
            {
                // Reduce el valor del campo "Fill amount"
                fillAmount -= Time.deltaTime;
            }
        }

        Orbit();
    }

    private void CalcularVector()
    {
        //detiene la orbita de la flecha de direccion
        orbitalSpeed = 0f;

        //calcula el vector de direccion
        Vector3 dir = (transform.position - centerOfMass.position).normalized;

        //calcula la fuerza del impulso
        float fuerza = barraFuerza.sizeDelta.y * 10f;

        //le da impulso en la direccion del vector dir
        centerOfMass.GetComponent<Rigidbody>().AddForce(dir * fuerza, ForceMode.Impulse);

        barra();
    }

    //orbita donde se hace el movimiento de nuestro indicador
    void Orbit()
    {

        transform.RotateAround(centerOfMass.position, Vector3.up, orbitalSpeed * Time.deltaTime);
    }

    //funcion en la cual voy a sibor y bajar gradualmente el fill amoun en mi imagen
    void barra()
    {
        force.fillAmount = 25 / 100;
    }

    // Inicializar la variable barraFuerza
    private void Awake()
    {
        barraFuerza = GetComponent<RectTransform>();

    }
}