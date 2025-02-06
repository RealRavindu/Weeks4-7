using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourHandScript : MonoBehaviour
{

    public float rotateSpeed = -0.05f;
    private float currentRotation;

    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.tag == "MinuteHand")
        {
            rotateSpeed *= 12;

        }
    }

    // Update is called once per frame
    void Update()
    {

        currentRotation += rotateSpeed;
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z + currentRotation);

    }
}
