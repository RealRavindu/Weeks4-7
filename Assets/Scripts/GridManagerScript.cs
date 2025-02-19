using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManagerScript : MonoBehaviour
{
    public List<GameObject> tileList = new List<GameObject>();
    public List<GameObject> placedList = new List<GameObject>();
    public GameObject tile;
    public HandManagerScript HandManager;
    private Vector3 tilePlacementPosition = Vector3.zero;
    int tileID =0;
    public float rowNum = 8;
    public float colNum = 8;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<rowNum; i++)
        {
            for(int j=0; j<colNum; j++)
            {
                tileID++;
                if(tileID == 2)
                {

                } else if(tileID == 7)
                {

                }
                instantiateTile(i, j);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            placeTile();
        }

        if (Input.GetMouseButton(1))
        {
            removeTile();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Tiles in placed list");
            foreach(GameObject T in placedList)
            {
                Debug.Log(T.transform.position);
            }
        }
        
    }

    void instantiateTile(float i, float j)
    {
        GameObject spawnedTile = Instantiate(tile, new Vector2(i+0.5f, j + 0.5f), Quaternion.identity);
        tileList.Add(spawnedTile);
    }

    void placeTile()
    {
        Debug.Log("Click went through checking if placable");
        foreach (GameObject T in tileList)
        {
            tilePlacementPosition = T.transform.position;
            tilePlacementPosition.z = -1;
            GridTile tileScript = T.GetComponent<GridTile>();
            if (HandManager.inHand != null && tileScript.checkIfHover() && !tileScript.containsTile)
            {
                tileScript.containsTile = true;
                Debug.Log("Placeable, placing at: " + T.transform.position);
                GameObject placedTile = Instantiate(HandManager.inHand, tilePlacementPosition, HandManager.inHand.transform.rotation);
                placedList.Add(placedTile);
            }
        }
    }

    void removeTile()
    {
        Debug.Log("Click went through checking if removable");
        foreach (GameObject T in placedList)
        {
            FactoryPartScript tileScript = T.GetComponent<FactoryPartScript>();
            if (HandManager.itemID == 0 && tileScript.checkIfHover())
            {
                Debug.Log("Removable, removing at: " + T.transform.position);
                placedList.Remove(T);
                tileScript.deleteTile();
            }
        }
        foreach (GameObject T in tileList)
        {
            GridTile tileScript = T.GetComponent<GridTile>();
            if (HandManager.inHand == null && tileScript.checkIfHover() && tileScript.containsTile)
            {
                tileScript.containsTile = false;
            }
        }
    }
}
