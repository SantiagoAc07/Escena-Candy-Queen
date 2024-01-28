using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileDespawner : MonoBehaviour
{
    private float initialTimer = 5f;
    private float bulletTimer;

    // Update is called once per frame
    void Update()
    {
        if(bulletTimer <= 0f)
        {
            gameObject.SetActive(false);
            bulletTimer = initialTimer;
        }
        else
        {
            bulletTimer -= Time.deltaTime;
        }
    }
}
