using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftScript : MonoBehaviour
{

    Rigidbody2D rbody;
    public cameraScript cam;
    Transform trsfm, camTrsfm;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        cam = FindObjectOfType<cameraScript>();
        trsfm = GetComponent<Transform>();
        camTrsfm = cam.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy helicopter if past the camera's view
        if (trsfm.position.x < camTrsfm.position.x - 15)
        {
            Destroy(gameObject);
        }

        rbody.velocity = new Vector2(-1, 0);
        
    }
}
