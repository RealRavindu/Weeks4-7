using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSpawner : MonoBehaviour
{

    public GameObject prefab;
    public Bullet bullet;
    // Start is called before the first frame update
    void Start()
    {
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fire();
            spawn();
        }
        
    }


    void spawn()
    {
        GameObject spawnedBullet = Instantiate(prefab);
        bullet = spawnedBullet.GetComponent<Bullet>();

    }

    void fire()
    {
        bullet.hasBeenFired = true;
        bullet = null;
    }
}
