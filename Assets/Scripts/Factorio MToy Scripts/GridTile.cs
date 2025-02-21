using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour
{
    private SpriteRenderer sr;
    public bool containsTile = false;
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        checkIfHover();
    }

    //checks if mouse is over it by checking the mouse's x and y positions against the tile's x and y positions with space given to the scale of it.
    public bool checkIfHover()
    {
        //converts the mouse position from screen to world so that it can be checked against the tile's transform.position accurately.
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 position = transform.position;
        
        //also changes the color of the tile if the mouse is detected over it whilst returning true or false
        if (mousePos.x < position.x + 0.5f && mousePos.x > position.x - 0.5f && mousePos.y < position.y + 0.5f && mousePos.y > position.y - 0.5f)
        {
            sr.color = new Color(0,0,1,1f);
            return true;
        } else
        {
            sr.color = Color.white;
            return false;
        }
    }
}
