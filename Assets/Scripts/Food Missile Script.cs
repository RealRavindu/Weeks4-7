using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodMissileScript : MonoBehaviour
{

    public List<Sprite> FoodList = new List<Sprite>();
    private SpriteRenderer SR;
    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        SR.sprite = FoodList[(int)Random.Range(0, FoodList.Count)];
        //Ground level is -0.428
    }

    // Update is called once per frame
    void Update()
    {

    }
}
