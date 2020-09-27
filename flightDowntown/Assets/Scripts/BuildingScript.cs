using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    public cameraScript cam;
    Transform trsfm, camTrsfm;

    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<cameraScript>();
        trsfm = GetComponent<Transform>();
        camTrsfm = cam.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (trsfm.position.x < camTrsfm.position.x - 15)
        {
            Destroy(gameObject);
        }
    }
}
