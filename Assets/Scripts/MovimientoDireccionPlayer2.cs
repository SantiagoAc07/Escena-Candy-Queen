using UnityEngine;
using UnityEngine.UI;

public class MovimientoDireccionPlayer2 : MonoBehaviour


{
    [SerializeField] private Rigidbody playerRB; //Rigidbody del personaje
    [SerializeField] private float fuerza; //Valor de fuerza
    [SerializeField] GameObject PowerBarP2; //Barra de Potencia (Visual)
    public static MovimientoImpulsoPlayer2 movimientoImpulso; //Conseguir el script de Impulso del jugador
    public Image medidorFuerza; //Controllador de potencia (Visual)
    public Transform centerOfMass; //Conseguir el Centro de Masa
    public float orbitalSpeed; //Velocidad orbital
    public int estado = 0; //Estado de movimiento del jugador
    private Vector3 dir; //Dirección
    private float fuerzaCalculada;

    [SerializeField] Rigidbody rb;

    public static bool direccion;

    void Start()
    {

        rb = GetComponent<Rigidbody>(); //Obtener el rigidbody del personaje
        PowerBarP2.SetActive(false); //Desactivar la barra de potencia (Visual)
    }

    // Update is called once per frame
    void Update()
    {
        movimientoImpulso = GetComponent<MovimientoImpulsoPlayer2>();

        Orbit();
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (estado == 0) 
            {
                CalcularVector(); //Método de dirección
                PowerBarP2.SetActive(true); //Activar la barra de potencia (Visual)
                estado++;
            }
            else if (estado == 1)
            {
                Impulsar(); //Método de impulso
                PowerBarP2.SetActive(false); //Desactivar la barra de potencia (Visual)
            }
        }
    }

    public void CalcularVector()
    {
        
        orbitalSpeed = 0f; //detiene la orbita de la flecha en la dirección seleccionada

       
        dir = (transform.position - centerOfMass.position).normalized;  //calcula el vector de dirección

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
