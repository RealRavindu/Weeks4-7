using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseTrapScript : MonoBehaviour
{
    public float timerValue;
    public float timerGap;
    public float positionScale;
    private Vector2 startingPosition;
    public AnimationCurve curve;
    private float t=0f;
    private Vector2 position;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime/timerValue;
        position.y = curve.Evaluate(t%timerGap);
        position.y *= positionScale;
        position.y += startingPosition.y;
        transform.position = position;

        
    }
}
