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

        //right click gets rid of the gameobject from the hand by deleting it.
        if (Input.GetMouseButtonDown(1))
        {
            itemID = 0;
            Destroy(inHand);
        }

        //rotates the gameObject in hand by 90 degrees clockwise.
        if (Input.GetKeyDown(KeyCode.R))
        {
            inHand.transform.Rotate(0,0,-90);
            
        }
    }
    
    //makes the spawned gameobject follow the cursor.
    void holding()
    {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = -1;
            if(inHand != null)
            {
                inHand.transform.position = mousePos;
            }
        
    }

    //spawns a gameobject that is now 'in the hand' i.e. following the mouse cursor and enables CERTAIN interactions with the grid while disabling other interactions.
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
