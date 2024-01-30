using UnityEngine;
using UnityEngine.UI;

public class MovimientoDireccionPlayer2 : MonoBehaviour


{
    [SerializeField] private Rigidbody playerRB;
    [SerializeField] private float fuerza;
    [SerializeField] GameObject PowerBarP2;
    public static MovimientoImpulsoPlayer2 movimientoImpulso;
    public Image medidorFuerza;
    public Transform centerOfMass;
    public float orbitalSpeed;
    public int estado = 0;
    private Vector3 dir;
    private float fuerzaCalculada;

    [SerializeField] Rigidbody rb;

    public static bool direccion;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        PowerBarP2.SetActive(false);
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
                CalcularVector();
                PowerBarP2.SetActive(true);
                estado++;
            }
            else if (estado == 1)
            {
                Impulsar();
                PowerBarP2.SetActive(false);
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
