using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    public List<Sprite> ParticleSpriteList = new List<Sprite>();
    private float t;
    private bool isMoving=false;
    private Vector2 startPos;
    private Vector2 endPos;
    // Start is called before the first frame update
    void Start()
    {
        //since lerp is happening constantly, sets start and end pos to it's actual position so that it doesn't go to 0,0 in the world.
        moveParticle();
    }

    // Update is called once per frame
    void Update()
    {
        //lerps from it's position to 1 unit down.
            t += Time.deltaTime;
            transform.position = Vector2.Lerp(startPos, endPos, t);

    }

    //selects the sprite it should have at the start through a list. Called by the outputter upon spawning.
    public void selectParticleSprite(int type)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = ParticleSpriteList[type];
    }

    //resets start and end pos to reflect it's new position and resets 0 so that the lerp animation can begin again.
    public void moveParticle()
    {
        
            startPos = transform.position;
            endPos = startPos + Vector2.down;
        t = 0;

    }

}
