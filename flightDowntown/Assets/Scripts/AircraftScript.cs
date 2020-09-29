using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftScript : MonoBehaviour
{

    Rigidbody2D rbody;
    Transform trsfm;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        trsfm = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy helicopter if past the camera's view
        if (trsfm.position.x < Camera.main.GetComponent<Transform>().position.x - 15)
        {
            Destroy(gameObject);
        }

        rbody.velocity = new Vector2(-1, 0);
        
    }
}
