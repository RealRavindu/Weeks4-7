using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryPartScript : MonoBehaviour
{
    public List<Sprite> spriteList = new List<Sprite>();
    public int partNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        //chooses the right sprite from a list. All parts behave the same way so a list to choose the sprite made sense.
        gameObject.GetComponent<SpriteRenderer>().sprite = spriteList[partNumber];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //deletes itself
    public void deleteTile()
    {
        Destroy(gameObject);
    }

    //checks if the mouse is between it's dimensions and returns true if so. This code is explained more in-depth in the GridTile script.
    public bool checkIfHover()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 position = transform.position;

        if (mousePos.x < position.x + 0.5f && mousePos.x > position.x - 0.5f && mousePos.y < position.y + 0.5f && mousePos.y > position.y - 0.5f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
