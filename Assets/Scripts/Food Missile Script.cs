using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class FoodMissileScript : MonoBehaviour
{
    public List<Sprite> FoodList = new List<Sprite>();
    private SpriteRenderer SR;
    public GameObject gravPrefab;
    public GameObject gravCalc;
    public GravityScript gravScript;
    public GameObject explosionPrefab;
    public float forceScale = 2.5f;
    public float mass = 1f;
    public Vector2 velocity = Vector2.zero;
    private Vector2 position;
    private Vector2 force;
    // Start is called before the first frame update
    void Start()
    {

        SR = GetComponent<SpriteRenderer>();
        SR.sprite = FoodList[(int)Random.Range(0, FoodList.Count)];
        gravCalc = Instantiate(gravPrefab);
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
        position += gravScript.FV;
        force = gravScript.force;
        transform.position = position;
        velocity = gravScript.FV;
        //Debug.Log("force is: " + force);
    }
    
    void collisionDetection()
    {
        if(transform.position.y <= -1.228)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gravCalc);
            Destroy(gameObject);
        }

    }
}
