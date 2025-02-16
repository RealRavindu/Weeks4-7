using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSript : MonoBehaviour
{
    public GameObject tank;
    public AnimationCurve explosionCurve;
    private float t = 0;
    public Vector2 explosionForce;
    private Vector2 distance;
    public float explosionSize = 20f;
    // Start is called before the first frame update
    void Start()
    {
        tank = GameObject.FindGameObjectWithTag("Player");
        distance = tank.transform.position - transform.position;
            if (distance.magnitude < explosionSize)
        {
            propel();
        }


    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        transform.localScale = Vector3.one * explosionCurve.Evaluate(t);
        if(t>1)
        {
            Destroy(gameObject);
        }
        
    }

    void propel()
    {
        Debug.Log("BOOOOOOOOOOOOOOOOOOOOOM!!!!!!!");        
        explosionForce = (distance*200) / explosionSize;
        Debug.Log("Size of explosion is: " + explosionForce);
        TankMovementScript tankScript = tank.GetComponent<TankMovementScript>();
        tankScript.resultantForce += explosionForce;
    }
}
