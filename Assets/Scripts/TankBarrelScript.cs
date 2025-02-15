using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TankBarrelScript : MonoBehaviour
{
    public Vector2 distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //Debug.Log ("Mouse position is: " + Camera.main.ScreenToWorldPoint(Input.mousePosition));
        //Debug.Log("Position is: " + transform.position);
        //Debug.Log("Distance is: " + distance);
        transform.right = distance; 
    }

    
}
