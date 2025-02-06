using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject prefab;
    public GameObject bullet;

    void Start()
    {
        Spawn();
    }

    void Update()
    {
        if(bullet == null)
        {
            Spawn();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Spawn()
    {
        bullet = Instantiate(prefab);
    }

    void Fire()
    {

    }
}
