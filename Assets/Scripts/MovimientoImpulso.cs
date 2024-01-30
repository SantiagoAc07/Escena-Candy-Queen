using UnityEngine;
using UnityEngine.UI;

public class MovimientoImpulso : MonoBehaviour
{
    MovimientoDireccion movimientoDireccion;
    public Image imagen;
    public float speed = 0.20f;
    private bool isIncreasing = true;

    public bool presX = false;

    void Awake()
    {
        movimientoDireccion = GetComponent<MovimientoDireccion>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            presX = true;
        }

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
    }
}
