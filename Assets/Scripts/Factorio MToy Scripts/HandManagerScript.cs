using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManagerScript : MonoBehaviour
{
    public int itemID;
    public GameObject prefabFactoryPart;
    public GameObject inHand;
    Quaternion rotationAxis = new Quaternion(0,0,0,0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        holding();

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right click clicked");
            itemID = 0;
            Destroy(inHand);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            inHand.transform.Rotate(0,0,-90);
            Debug.Log("Current rotation: " + inHand.transform.rotation + " |Current position: " + inHand.transform.position);
        }
    }
    
    void holding()
    {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = -1;
            if(inHand != null)
            {
                inHand.transform.position = mousePos;
            }
        
    }
    public void clickButtonFactoryPart(int number)
    {

        itemID = number;
        Destroy(inHand);
        inHand = GameObject.Instantiate(prefabFactoryPart);
        FactoryPartScript tileScript = inHand.GetComponent<FactoryPartScript>();
        tileScript.partNumber = itemID;
        inHand.transform.rotation = rotationAxis;
        Debug.Log("button clicked, this is itemID: " + itemID + " |inHand transform: " + inHand.transform.position);
    }
}
