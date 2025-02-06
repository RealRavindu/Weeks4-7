
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementScript : MonoBehaviour
{
    public float speed;
    public float maxDistance = 2f;
    bool collided = false;
    bool lastTime;
    public List<Transform> NPCPositions;
    List<bool> interactionList = new List<bool>();
    public Image Bubble;
    public List<Sprite> SpriteList = new List<Sprite>();
    Vector2 direction = Vector2.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach(bool T in interactionList)
        {
            interactionList.Add(T);
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkCollision();
        Movement();
        
    }

    void checkCollision()
    {
        for(float i=0; i<NPCPositions.Count; i++)
        {

            Vector2 Line = NPCPositions[(int)i].position - transform.position;
            float distance = Line.magnitude;
            if (distance < maxDistance)
            {
                print("hello collision");
                lastTime = true;
                if (!interactionList[(int)i])
                {
                    changeEmote();
                }
            }
            else
            {
                interactionList[(int)i] = false;
            }

            interactionList[(int)i] = lastTime;
        }
    }

    void changeEmote()
    {
        Sprite chosenSprite = SpriteList[(int) Random.Range(0, SpriteList.Count)];
        Bubble.sprite = chosenSprite;
    }

    void Movement()
    {
        direction = transform.position;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up * speed * Time.deltaTime;
            transform.position = direction;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down * speed * Time.deltaTime;
            transform.position = direction;
        }
        if (Input.GetKey(KeyCode.A))
        {
            print("hello");
            direction += Vector2.left * speed * Time.deltaTime;
            transform.position = direction;
        }
        if (Input.GetKey(KeyCode.D))
        {
            print("hello");
            direction += Vector2.right * speed * Time.deltaTime;
            transform.position = direction;
        }
    }
}
