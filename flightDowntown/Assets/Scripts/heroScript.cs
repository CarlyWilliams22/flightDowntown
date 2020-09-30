using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heroScript : MonoBehaviour
{
    Rigidbody2D rbody;
    public MSMScript msm;
    public ceilingScript ceiling;
    public cameraScript cam;
    public Text gameOverText;
    AudioSource sound;
    public AudioClip gameOverSound;
    public AudioClip hitSound;
    bool gameOver;
    float x;
    float y;
    Collider2D heroCollider;
    Transform trsfm;

    // Start is called before the first frame update
    void Start()
    {
        rbody = gameObject.GetComponent<Rigidbody2D>();
        heroCollider = GetComponent<Collider2D>();
        gameOverText.gameObject.SetActive(false);
        sound = GetComponent<AudioSource>();
        trsfm = GetComponent<Transform>();

        gameOver = false;

    }

    // Update is called once per frame
    void Update()
    {
        //if gameOver is true player can no longer jump
        if (!gameOver)
        {
            //jumps only when space bar is pressed
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rbody.AddForce(new Vector2(0, 300));
            }
        }

        //keeps ceiling above hero
        x = trsfm.position.x;
        y = ceiling.GetComponent<Transform>().position.y;
        ceiling.GetComponent<Transform>().position = new Vector2(x, y);


        //Lose if the hero goes too low
        if(!gameOver && trsfm.position.y < -10)
        {
            cam.gameOver();

            //plays game over sounds
            msm.sound.Stop();
            sound.PlayOneShot(gameOverSound);
            sound.PlayOneShot(hitSound);

            //disables player movement and allows the hero to fall below the screen 
            gameOver = true;
            heroCollider.enabled = !heroCollider.enabled;

            gameOverText.gameObject.SetActive(true);

            //sets the highscore
            msm.SetHighScore();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //loses if player hits an obstacle 
       if(collision.gameObject.tag.Equals("obstacle"))
        {
            cam.gameOver();

            //plays game over sounds
            msm.sound.Stop();
            sound.PlayOneShot(gameOverSound);
            sound.PlayOneShot(hitSound);

            //disables player movement and allows the hero to fall below the screen 
            gameOver = true;
            heroCollider.enabled = !heroCollider.enabled;

            gameOverText.gameObject.SetActive(true);

            //sets the highscore
            msm.SetHighScore();
        }
    }
}
