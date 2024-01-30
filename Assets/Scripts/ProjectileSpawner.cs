using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public Transform launchPoint; //Punto de lanzamiento
    public GameObject projectile; //Proyectil
    public float launchSpeed = 10f; //Velocidad de lanzamiento

    public bulletPool pool;

    private float _shootTimeRemeaning; //Tiempo entre disparos

    private bool _canShoot = false; //Identificador de que puede disparar
    
    void Update (){
        if (_shootTimeRemeaning <= 0) 
        {
            _canShoot = true;            
        }
        else
        {
            _shootTimeRemeaning -= Time.deltaTime;            
        }

        //accionar la intanciacion de un objeto 
        if(Input.GetKeyDown(KeyCode.Space)){
            if (_canShoot)
            {
                Shoot(); //llama al método de disparo 
            }
            
        }
    }

    public void Shoot() //Metodo de disparo
    {
        var _projectile = pool.RequestProyectile(); //Consigue el proyectil
        _projectile.transform.SetPositionAndRotation(launchPoint.position, launchPoint.rotation); //C0onseguir la posición de lanzamiento
        _projectile.GetComponent<Rigidbody>().velocity = launchPoint.forward * launchSpeed; //Consigue el rigidbody
        _canShoot = false; //Desactiva el disparo
        _shootTimeRemeaning = 2.8f; //Tiempo entre disparos
    }
}
