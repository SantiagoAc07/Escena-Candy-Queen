using UnityEngine;
using UnityEngine.UI;

public class MovimientoJugador : MonoBehaviour
{
    public Transform centerOfMass;
    public float orbitalSpeed;
    public float scale = 1.0f;

    public Image force;

    public RectTransform barraFuerza;

    public float fillAmount;

    private void Awake()
    {
        barraFuerza = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            barra();
        }
        else
        {
            fillAmount += Time.deltaTime;

            if (fillAmount > 100f)
            {
                fillAmount -= Time.deltaTime;
            }
        }

        Orbit();
    }

    private void CalcularVector()
    {
        orbitalSpeed = 0f;

        Vector3 dir = (transform.position - centerOfMass.position).normalized;

        float fuerza = barraFuerza.sizeDelta.y * 10f;

        centerOfMass.GetComponent<Rigidbody>().AddForce(dir * fuerza, ForceMode.Impulse);

        barra();
    }

    void Orbit()
    {
        transform.RotateAround(centerOfMass.position, Vector3.up, orbitalSpeed * Time.deltaTime);
    }

    void barra()
    {
        force.fillAmount = 25 / 100;
    }
}