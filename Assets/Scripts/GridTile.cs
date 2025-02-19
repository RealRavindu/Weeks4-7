using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour
{
    private SpriteRenderer sr;
    bool isMouseHovering = false;
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

    public bool checkIfHover()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 position = transform.position;
        
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
