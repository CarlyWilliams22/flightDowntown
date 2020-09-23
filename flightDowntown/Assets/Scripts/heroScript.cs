using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroScript : MonoBehaviour
{
    Rigidbody2D rbody;
    public ceilingScript ceiling;
    float x;
    float y;

    // Start is called before the first frame update
    void Start()
    {
        rbody = gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rbody.AddForce(new Vector2(0, 300));
        }

        x = gameObject.GetComponent<Transform>().position.x;
        y = ceiling.GetComponent<Transform>().position.y;
        ceiling.GetComponent<Transform>().position = new Vector2(x, y);



    }
}
