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
        rbody.velocity = new Vector2(5, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        x = gameObject.GetComponent<Transform>().position.x -5;
        y = hero.GetComponent<Transform>().position.y;

        hero.GetComponent<Transform>().position = new Vector2(x, y);

    }
}
