using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tankmovement : MonoBehaviour
{
    private float speed = 10f;
    private float jumpForce = 40f;
    public AnimationCurve curve;
    public SpriteRenderer spr;
    public GameObject prefab;
    public GameObject cloud;
    private bool isJumping = false;
    [Range (0,1)]
    public float t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
        transform.position = pos;

        Vector2 keepInScreen = Camera.main.WorldToScreenPoint(pos);

        if (keepInScreen.x > Screen.width || keepInScreen.x < 0)
        {
            speed *= -1;
            Vector2 reflection = new Vector2(-1, 1);
            transform.localScale *= reflection;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            cloud = Instantiate(prefab);
            isJumping = true;
        }

        if (isJumping)
        {
            t += Time.deltaTime;
            Jump();

        } else
        {
            t = 0;
        }
    }

    void Jump()
    {

        spr.color = Color.red;
        transform.position += transform.up * jumpForce * Time.deltaTime * curve.Evaluate(t);

        if (t >= 1)
        {
            spr.color = Color.white;
            isJumping = false;

        }
    }
}
