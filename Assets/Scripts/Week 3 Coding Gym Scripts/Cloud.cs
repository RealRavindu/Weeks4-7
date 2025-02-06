using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{

    public float speed = 0.5f;
    private float t;
    // Start is called before the first frame update
    void Start()
    {
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        transform.position += transform.up * speed * Time.deltaTime;
        if (t < 200f)
        {
            Destroy(gameObject);
        }
    }
}
