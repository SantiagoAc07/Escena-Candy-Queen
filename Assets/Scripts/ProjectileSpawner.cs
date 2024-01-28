using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public Transform launchPoint;
    public GameObject projectile;
    public float launchSpeed = 10f;

    public bulletPool pool;

    private float _shootTimeRemeaning;

    private bool _canShoot = false;
    
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
                Shoot();
            }
            
        }
    }

    public void Shoot()
    {
        var _projectile = pool.RequestProyectile();
        _projectile.transform.SetPositionAndRotation(launchPoint.position, launchPoint.rotation);
        _projectile.GetComponent<Rigidbody>().velocity = launchPoint.forward * launchSpeed;
        _canShoot = false;
        _shootTimeRemeaning = 2.8f;
    }
}
