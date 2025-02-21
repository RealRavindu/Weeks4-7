using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManagerScript : MonoBehaviour
{
    public List<GameObject> tileList = new List<GameObject>();
    public List<GameObject> placedList = new List<GameObject>();
    public List<GameObject> outputterList = new List<GameObject>();
    public CanvasScript canvasScript;
    public GameObject tile;
    public GameObject outputterPrefab;
    public GameObject inputterPrefab;
    public Slider speedSlider;
    private int inputterType;
    private int outputterType;
    public HandManagerScript HandManager;
    private int randomInputterLocation;
    private Vector3 tilePlacementPosition = Vector3.zero;
    int tileID =0;
    private float t;
    public bool playing = false;
    public float rowNum = 8;
    public float colNum = 8;
    public float tickGap = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //chooses a random location for the third inputter (for fun gameplay reasons :D)
        chooseRandomInputterLocation();

        //nested loops that generate the tile grid, with exceptions built in to allow space for the outputters and inputters which are not interactable tiles. They have nothing
        //in common with the other tiles other than just fitting in the grid visually.
        for(int j=0; j< colNum; j++)
        {
            for (int i = 0; i < rowNum; i++)
            {
                tileID++;
                if (tileID == 58 || tileID ==63)
                {
                    spawnOutputter(i, j, outputterType);
                    outputterType++;

                } else if (tileID == 2 || tileID == 7 || tileID == randomInputterLocation)
                {

                    spawnInputter(i, j, inputterType);
                    inputterType++;
                } else
                {
                    instantiateTile(i, j);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //changing the value of the tickGap using the second slider's value. The point of the tickGap is so that I can make certain functions run every x frame,
        //instead of every frame in update.
        tickGap = speedSlider.value * 3;
        if (playing)
        {
            t += Time.deltaTime;
            if (t > tickGap)
            {
                foreach(GameObject T in outputterList)
                {
                    //moves and spawns particles every tick
                    T.GetComponent<OutputterScript>().moveParticles();
                    T.GetComponent<OutputterScript>().spawnParticle();
                }
                t = 0;
            }
        }

        
        //right click triggers remove tile function
        if (Input.GetMouseButton(1))
        {
            removeTile();
        }

        //left alt makes the overlays appear and disappear, just like in the real game :D
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            canvasScript.toggleOverlays();
        }
    }
    //the code at the start that chooses a random location for the third inputter that requires red science
    void chooseRandomInputterLocation()
    {
        //there are exceptions built in to ensure this inputter |1) doesnt get placed over another inputter |2) doesnt get placed DIRECTLY infront of another inputter.
        randomInputterLocation = (int)Random.Range(1, 24);
        if (randomInputterLocation == 2 || randomInputterLocation == 7 || randomInputterLocation == 10 || randomInputterLocation == 15)
        {
            chooseRandomInputterLocation();
        }
    }

    //creates a tile of class tilegrid and gives it i and j as transform.position coordinates.
    void instantiateTile(float i, float j)
    {
        GameObject spawnedTile = Instantiate(tile, new Vector2(i+0.5f, j + 0.5f), Quaternion.identity);
        tileList.Add(spawnedTile);
    }

    //finds which tile the cursor is hovering over using a function built into the tiles called checkIfHover() and also checks if the cursor is holding a gameobject AND that
    //there's nothing else already occupying that tile. After placing, it adds it to a list called placedTiles
    void placeTile()
    {
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

    //checks if nothing is being held by the cursor and that it's hovering over an already placed tile using the placedTile list and the same checkIfHover function that's in the normal
    //tiles
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
                //the function breaks after deleting cuz otherwise it'll keep going through the list and break the program since it'll look for an extra tile that the list
                //doesn't hold anymore.
                break;
            }
        }
        foreach (GameObject T in tileList)
        {
            GridTile tileScript = T.GetComponent<GridTile>();
            if (HandManager.inHand == null && tileScript.checkIfHover() && tileScript.containsTile)
            {
                tileScript.containsTile = false;
                break;
            }
        }
    }

    //spawns an outputter with coordinates and a type (of particle it should spawn). Also adds it to a list of outputters.
    void spawnOutputter(float i, float j, int type)
    {
        GameObject spawnedOutputter = Instantiate(outputterPrefab, new Vector2(i + 0.5f, j + 0.5f), Quaternion.identity);
        OutputterScript outputterScript = spawnedOutputter.GetComponent<OutputterScript>();
        outputterScript.typeOfParticle = type;
        canvasScript.spawnOverlay(type, spawnedOutputter.transform.position, spawnedOutputter.transform.rotation);
        outputterList.Add(spawnedOutputter);
    }

    //spawns an inputter with coordinates anda type (of particle it should accept). Also adds it to a list of inputters.
    void spawnInputter(float i, float j, int type)
    {
        GameObject spawnedInputter = Instantiate(inputterPrefab, new Vector2(i + 0.5f, j + 0.5f), Quaternion.identity);
        InputterScript inputterScript = spawnedInputter.GetComponent<InputterScript>();
        inputterScript.typeOfParticle = type;
        canvasScript.spawnOverlay(type, spawnedInputter.transform.position, spawnedInputter.transform.rotation);
    }


    //triggered by the play button. A bool is used to check if it was play before being clicked. If it was in restart mode, then instead of playing again, it does the restart procedure
    //which erases everything on the map and sets the playing boolean to false. If it was in play mode before being clicked, it'll play the game and start spawning particles.
    public void clickPlay()
    {
        Debug.Log("PLAY CLICKED");
        if (playing)
        {
            restartProcedure();
        } else
        {
            t = 0;
            playing = true;
        }
    }

    //the restart procedure that goes through all the particle lists in each outputter and erases all of them and sets play to false so that no more particles spawn.
    public void restartProcedure()
    {
        Debug.Log("RESTART PROCEDURE");
        playing = false;
        foreach(GameObject T in outputterList)
        {
            OutputterScript outScript = T.GetComponent<OutputterScript>();
            foreach(GameObject P in outScript.particleList)
            {
                Destroy(P);
            }
        }
    }
}
