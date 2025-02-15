using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScript : MonoBehaviour
{
    public Vector2 force;
    public float GravScale = 0.6f;
    private Vector2 gravity;
    public float mass;
    private Vector2 acceleration;
    public Vector2 IV = Vector2.zero;
    public Vector2 FV;
    // Start is called before the first frame update
    void Start()
    {
        gravity = Vector2.down * GravScale;

        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("force: " + force + " mass: " + mass + "acceleration: " + acceleration + "IV: " + IV + "gravity: " + gravity);
        
    }

    public void gravitf()
    {
        acceleration = force / mass;
        FV = IV + acceleration * Time.deltaTime;
        force += gravity;

    }
}
