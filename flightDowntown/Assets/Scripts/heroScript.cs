using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heroScript : MonoBehaviour
{
    Rigidbody2D rbody;
    public MSMScript msm;
    public ceilingScript ceiling;
    public cameraScript camera;
    public Text gameOverText;
    AudioSource audio;
    public AudioClip gameOverSound;
    bool gameOver;
    float x;
    float y;
    Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        rbody = gameObject.GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        gameOver = false;
        gameOverText.gameObject.SetActive(false);
        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        if (!gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rbody.AddForce(new Vector2(0, 300));
            }
        }

        x = gameObject.GetComponent<Transform>().position.x;
        y = ceiling.GetComponent<Transform>().position.y;
        ceiling.GetComponent<Transform>().position = new Vector2(x, y);



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag.Equals("obstacle"))
        {
            camera.gameOver();
            msm.audio.Stop();
            audio.PlayOneShot(gameOverSound);
            gameOver = true;
            collider.enabled = !collider.enabled;
            gameOverText.gameObject.SetActive(true);
        }
    }
}
