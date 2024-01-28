using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bulletPool : MonoBehaviour
{
    public int poolSize;
    //public Bullet;
    public GameObject bullet;
    private GameObject proyectil;
//aqui cambiamos tipo Gameobject a bullet ejm
    public List<GameObject> bulletList;

    void Start()
    {   
        _initialTimeRemaining = _shootTimeRemeaning;
       AddProyectilePool(poolSize); 
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void AddProyectilePool(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
             proyectil = Instantiate(bullet);
            proyectil.SetActive(false);
            bulletList.Add(proyectil);
            proyectil.transform.parent = transform;
        }
        
    }

    public GameObject RequestProyectile()
    {
        foreach(GameObject proyectile in bulletList)
        {
            if(!proyectile.gameObject.activeSelf)
            {
                proyectile.gameObject.SetActive(true);
                return proyectile;
            }            
        }    
        AddProyectilePool(1);
        bulletList[bulletList.Count - 1].gameObject.SetActive(true);
        return bulletList[bulletList.Count - 1];   
    }


//Imagen1
[SerializeField]
private float _shootTimeRemeaning = 5.0f;

[SerializeField]
private float _initialTimeRemaining;

//Start is called before the first frame update
}
