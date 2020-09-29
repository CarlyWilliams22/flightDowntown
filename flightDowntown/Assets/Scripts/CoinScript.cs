using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    public MSMScript msm;
    Transform trsfm;

    // Start is called before the first frame update
    void Start()
    {
        msm = FindObjectOfType<MSMScript>();
        trsfm = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy coin if past the camera's view
        if (trsfm.position.x < Camera.main.GetComponent<Transform>().position.x - 15)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //gain a point if the hero collides with a coin
        if (collision.gameObject.tag.Equals("Player"))
        {
            msm.IncrementScore();
            Destroy(gameObject);
        }
    }
}
