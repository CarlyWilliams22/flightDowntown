using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    Transform trsfm;

    // Start is called before the first frame update
    void Start()
    {
        trsfm = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy building if past the camera's view
        if (trsfm.position.x < Camera.main.GetComponent<Transform>().position.x - 15)
        {
            Destroy(gameObject);
        }
    }
}
