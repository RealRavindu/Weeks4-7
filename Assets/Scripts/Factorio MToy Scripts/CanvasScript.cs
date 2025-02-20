using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public GameObject overlayImagePrefab;
    public List<Sprite> overlayImages = new List<Sprite>();
    List<GameObject> overlaysList = new List<GameObject>();
    bool setActive = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {

        }
        
    }

    public void spawnOverlays(int i)
    {
        GameObject spawnedOverlay = Instantiate(overlayImagePrefab);
        Image spawnedOverlayImage = spawnedOverlay.GetComponent<Image>();
        spawnedOverlayImage.sprite = overlayImages[i];
        overlaysList.Add(spawnedOverlay);
    }

    void toggleOverlays()
    {
        if (setActive)
        {
            foreach(GameObject T in overlaysList)
            {
                Image overlayImage = T.GetComponent<Image>();
                overlayImage.enabled = false;
            }
            setActive = false;
        } else
        {
            foreach (GameObject T in overlaysList)
            {
                Image overlayImage = T.GetComponent<Image>();
                overlayImage.enabled = true;
            }
            setActive = true;
        }
    }
}
