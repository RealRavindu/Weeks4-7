using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovementScript : MonoBehaviour
{
    public GameObject gravPrefab;
    public GameObject gravCalc;
    public GravityScript GravityScript;
    public float frictionScale = 0.1f;
    public float mass = 10f;
    public float vertForceScale = 7f;
    public float horForceScale = 20f;
    public Vector2 resultantForce;
    public float groundLevel;
    public bool isGrounded;
    public bool movingLeft;
    public bool movingRight;
    private Vector2 horA;
    private Vector2 HFV;
    private Vector2 HIV=Vector2.zero;
    public Vector2 VFV;
    // Start is called before the first frame update
    void Start()
    {
        gravCalc = Instantiate(gravPrefab);
        GravityScript = gravCalc.GetComponent<GravityScript>();
        groundLevel = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (groundLevel >= transform.position.y)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        if (transform.position.y < groundLevel)
        {
            resultantForce = new Vector2 (resultantForce.x, 0f);
            Vector2 resetPosition = new Vector2 (transform.position.x, groundLevel);
            transform.position = resetPosition;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && isGrounded)
        {
            resultantForce = Vector2.left * horForceScale;
            movingLeft = true;
            movingRight = false;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && isGrounded)
        {
            resultantForce = Vector2.right * horForceScale;
            movingRight = true;
            movingLeft = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            jump();
        }
        if (!isGrounded)
        {
            falling();
        }

        if(resultantForce.magnitude != 0 && isGrounded)
        {
            friction();
        }

        velocityCalc();
        
    }

    void friction()
    {
        if (movingRight)
        {
            if (resultantForce.x > 0)
            {

                resultantForce += Vector2.left * frictionScale;
            } else
            {
                resultantForce = new Vector2(0, resultantForce.y); 
            }
            
        }
        if (movingLeft)
        {
            if (resultantForce.x < 0)
            {

                resultantForce += Vector2.right * frictionScale;
            }
            else
            {
                resultantForce =new Vector2(0, resultantForce.y);
            }
        }

    }

    void velocityCalc()
    {
        horA = resultantForce / mass;
        HFV = HIV + horA * Time.deltaTime;
        Vector2 hPosition = transform.position;
        hPosition += HFV;
        transform.position = hPosition;
    }

    void jump()
    {
        resultantForce += Vector2.up * vertForceScale;
        
    }

    void falling()
    {
        GravityScript.force = resultantForce;
        GravityScript.mass = mass;
        GravityScript.IV = VFV;
        GravityScript.gravitf();
        Vector2 vPosition = transform.position;
        resultantForce = GravityScript.force;
        vPosition += GravityScript.FV;
        transform.position = vPosition;
    }
    /*gravScript.force = force;
        gravScript.mass = mass;
        gravScript.IV = velocity;
        gravScript.gravitf();
        position += gravScript.FV * Time.deltaTime;
        force = gravScript.force;
        transform.position = position;
        velocity = gravScript.FV; */
}
