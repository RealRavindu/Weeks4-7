using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LogicManagerScript : MonoBehaviour
{
    public float RF = 0;
    public float Friction;
    public float accel;
    public float mass = 111.2f;
    public float VF;
    public float VI = 0;
    public float position = 0;
    public AnimationCurve curve;
    public AnimationCurve frictionCurve;

    // Start is called before the first frame update
    void Start()
    {
        mass = 111.2f;
    }

    // Update is called once per frame
    void Update()
    {
        //getting user inputs and adding to resultant force(RF)
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (RF < 2)
            {
                 RF += 0.6f;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (RF > -2)
            {
                RF += -0.6f;
            }
        }

        //capping RF to 2f on both sides
        if (RF > 2f)
        {
            RF = 2f;
        }
        if (RF < -2f)
        {
            RF = -2f;
        }



        //acceleration calculation
        accel = RF / mass;

        //Final velocity calculation
        VF = VI + accel * Time.deltaTime;
        VI = VF;

        //position calculation
        position += VF;
        if (position > 1 || position * -1 > 1)
        {
            position = position % 1;
        }
        if (position < 0)
        {
            position = 1 + position;
        }
        if (position > 1)
        {
            position = 1 - position;
        }
        //changing value of localscale
        Vector2 newScale = new Vector2(curve.Evaluate(position), 1);
        transform.localScale = newScale;
        if (VF < 0)
        {
            position = position - 1;
        }

        //setting the direction of friction depending on the direction of velocity
        if (VF >= 0 )
        {
            Friction = frictionCurve.Evaluate(VF) * -10;
        }
        else
        {
            Friction = frictionCurve.Evaluate(VF * -1) *10;
        }

        //if object is moving and RF is greater than friction, adding friction to RF (both in opposite directions so would be subtracting). If RF < Friction, setting RF to friction.
        if (VF != 0)
        {
            if (RF > Friction * -1 || RF * -1 > Friction)
            {
                
                RF += Friction;
                
            }
            else
            {
                RF = Friction;
            }
        }
        


    }
}
