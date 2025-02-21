using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasScript : MonoBehaviour
{
    public GameObject overlayImagePrefab;
    public List<Sprite> overlayImages = new List<Sprite>();
    List<GameObject> overlaysList = new List<GameObject>();
    public TMP_Text playText;
    private bool wasPlay=true;
    public Slider overlayOpacitySlider;
    bool setActive = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //slider value changes the opacity of the overlay images that show up over the inputters and outputters
        changeOverlayOpacity(overlayOpacitySlider.value);
        
    }

    //this function spawns the overlays on top of the inputters and outputters while keeping them as children of the canvas. I use the canvas's transform in the transform spot
    //to keep them children, then update their position and rotation after to place them over their respective tiles.
    //using a list of images to obtain the right one.
    public void spawnOverlay(int i, Vector3 position, Quaternion rotation)
    {
        GameObject spawnedOverlay = Instantiate(overlayImagePrefab, gameObject.transform);
        spawnedOverlay.transform.position = position;
        spawnedOverlay.transform.rotation = rotation;
        Image spawnedOverlayImage = spawnedOverlay.GetComponent<Image>();
        spawnedOverlayImage.sprite = overlayImages[i];
        overlaysList.Add(spawnedOverlay);
    }

    //function to enable and disable the overlays
    public void toggleOverlays()
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

    //the slider value used to change opacity by creating a new color where only the alpha gets affected by the value of the slider.
    public void changeOverlayOpacity(float value)
    {
        foreach (GameObject T in overlaysList)
        {
            Color overlayColor = T.GetComponent<Image>().color;
            overlayColor = new Color(overlayColor.r, overlayColor.g, overlayColor.b, value);
            T.GetComponent<Image>().color = overlayColor;
        }
    }

    //used a boolean to swap between 'play' and 'restart' when the button is clicked.
    public void changePlayButtonText()
    {
        if (wasPlay)
        {
            wasPlay = false;
            playText.text = "Restart";
        } else
        {
            wasPlay = true;
            playText.text = "Play";
        }
    }
}
