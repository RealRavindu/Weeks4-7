using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverScript : MonoBehaviour
{
    public float speed = 0.8f;
    private float t =0f;
    private Boolean isMoving = false;
    private Vector2 updatedPos;
    public AnimationCurve curve;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.8f;
        updatedPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && !isMoving)
        {
            updatedPos.y += -speed;
            isMoving = true;
            t = 0;

        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isMoving)
        {
            updatedPos.y += speed;
            isMoving = true;
            t = 0;

        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && !isMoving)
        {

            updatedPos.x += speed;
            isMoving = true;
            t = 0;

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !isMoving)
        {
            updatedPos.x += -speed;
            isMoving = true;
            t = 0;

        }

        if (isMoving)
        {
            moveMover();
        }

        t += Time.deltaTime;       
;

    }
    public void moveMover()
    {
        transform.position = Vector2.Lerp(transform.position, updatedPos, curve.Evaluate(t));
        if (t > 1)
        {
            isMoving = false;
        }
    }
}
