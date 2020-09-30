using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{

    Rigidbody2D rbody;
    float x;
    float y;
    public heroScript hero;

    // Start is called before the first frame update
    void Start()
    {
        rbody = gameObject.GetComponent<Rigidbody2D>();

        //starts the camera movement
        rbody.velocity = new Vector2(5, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        //moves the position of the hero to match the x = -5 position on the camera
        x = gameObject.GetComponent<Transform>().position.x -5;
        y = hero.GetComponent<Transform>().position.y;
        hero.GetComponent<Transform>().position = new Vector2(x, y);

    }

    //stops camera movement if the player dies
    public void gameOver()
    {
        rbody.velocity = new Vector2(0, 0);
    }
}
