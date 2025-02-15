using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodMissileScript : MonoBehaviour
{
    public List<Sprite> FoodList = new List<Sprite>();
    private SpriteRenderer SR;
    public GameObject gravCalc;
    public GravityScript gravScript;
    public float forceScale = 450.5f;
    public float mass = 3.2f;
    public Vector2 velocity = Vector2.zero;
    private Vector2 position;
    private Vector2 force;
    // Start is called before the first frame update
    void Start()
    {
        forceScale = 15f;
        SR = GetComponent<SpriteRenderer>();
        SR.sprite = FoodList[(int)Random.Range(0, FoodList.Count)];
        gravCalc = GameObject.FindGameObjectWithTag("gravity");
        gravScript = gravCalc.GetComponent<GravityScript>();
        Vector2 distance =  Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.up = distance.normalized;
        Debug.Log("THIS IS TRANSFORM UP OF BULLET: " + transform.up);
        force = transform.up * forceScale;
        transform.rotation = Quaternion.Euler(Vector3.zero);
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        collisionDetection();
        gravScript.force = force;
        gravScript.mass = mass;
        gravScript.IV = velocity;
        gravScript.gravitf();
        position += gravScript.FV * Time.deltaTime;
        force = gravScript.force;
        transform.position = position;
        velocity = gravScript.FV;
        //Debug.Log("force is: " + force);
    }
    
    void collisionDetection()
    {
        if(transform.position.y <= -1.228)
        {
            Destroy(gameObject);
        }

    }
}
