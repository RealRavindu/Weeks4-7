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
        gameObject.GetComponent<SpriteRenderer>().sprite = spriteList[partNumber];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void deleteTile()
    {
        Destroy(gameObject);
    }
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
