using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputterScript : MonoBehaviour
{
    public int typeOfParticle;
    public GameObject particlePrefab;
    public List<GameObject> particleList = new List<GameObject>();
    public Vector2 startPos;
    public Vector2 endPos;
    public float t;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //function that triggers moveParticle function in each particle it created.
    public void moveParticles()
    {
        Debug.Log("Particle moved");
        foreach(GameObject T in particleList)
        {
            T.GetComponent<ParticleScript>().moveParticle();
        }
    }

    //creates a particle and adds it to a list. Does not make the particle it's child. Also chooses a sprite for the particle depending on the outputter's type

    public void spawnParticle()
    {
        t = 0;
        Debug.Log("PARTICLE SPAWNED");
        GameObject spawnedParticle = Instantiate(particlePrefab, transform.position, transform.rotation);
        particleList.Add(spawnedParticle);
        spawnedParticle.GetComponent<ParticleScript>().selectParticleSprite(typeOfParticle);
    }

}
