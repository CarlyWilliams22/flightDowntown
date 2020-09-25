using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    public MSMScript msm;

    // Start is called before the first frame update
    void Start()
    {
        msm = FindObjectOfType<MSMScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        msm.IncrementScore();
        
        Destroy(gameObject);
    }
}
