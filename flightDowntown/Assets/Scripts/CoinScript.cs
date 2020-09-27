﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    public MSMScript msm;
    public cameraScript cam;
    Transform trsfm, camTrsfm;

    // Start is called before the first frame update
    void Start()
    {
        msm = FindObjectOfType<MSMScript>();
        cam = FindObjectOfType<cameraScript>();
        trsfm = GetComponent<Transform>();
        camTrsfm = cam.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(trsfm.position.x < camTrsfm.position.x - 15)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            msm.IncrementScore();
            Destroy(gameObject);
        }
    }
}
