using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MSMScript : MonoBehaviour
{
    public AircraftScript aircraftPrototype;
    public BuildingScript buildingPrototype;
    public CoinScript coinPrototype;
    public cameraScript cam;
    public AudioClip coinCollect;
    public AudioSource sound;
    Transform camTransform;
    float lastCamXb = 0;
    float lastCamXa = 0;
    float camX;
    public int deltaBuildings;
    public int deltaAircraft;
    float deltaDelta;
    public Text scoreText;
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        camTransform = cam.GetComponent<Transform>();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        camX = camTransform.position.x;

        //spawn a building and a few coins every deltaBuildings (+ deltaDelta)
        deltaDelta = Random.Range(0, 3);
        if(camX > lastCamXb + deltaBuildings + deltaDelta)
        {
            SpawnBuildingAndCoins((int)camX + 14);
            lastCamXb = camX;
        }

        //spawn a helicopter and a few coins every deltaAircraft (+ deltaDelta)
        deltaDelta = Random.Range(0, 3);
        if (camX > lastCamXa + deltaAircraft + deltaDelta)
        {
            SpawnAircraftAndCoins((int)camX + 17);
            lastCamXa = camX;
        }
    }

    void SpawnAircraftAndCoins(int x)
    {
        //Aircraft
        float y = Random.Range(5 - .625f, 2 + .625f);
        float xDiff = Random.Range(-1.125f, 1.125f);
        Instantiate(aircraftPrototype, new Vector2(x + xDiff, y), Quaternion.identity);

        //Coins
        int nCoins = 0;
        float coinX, coinY;

        while (nCoins < 1)
        {
            coinX = Random.Range(-deltaAircraft/2, deltaAircraft/2);
            coinY = Random.Range(2.1f, 4.9f);

            //make sure the coin does not spawn inside a helicopter
            if (!(coinY <= y+.75 && coinY >= y-.75  && x >= x+xDiff-2 && x <= x+xDiff+2))
            {
                Instantiate(coinPrototype, new Vector2(x + coinX, coinY), Quaternion.identity);
                nCoins++;
            }
        }
    }

    void SpawnBuildingAndCoins(int x)
    {
        //Building
        float scaleX = Random.Range(2, 5);
        float scaleY = Random.Range(2, 5.5f);
        BuildingScript building = Instantiate(buildingPrototype, new Vector2(x, -5 + scaleY / 2), Quaternion.identity);
        Transform buildingForm = building.gameObject.GetComponent<Transform>();
        buildingForm.localScale = new Vector2(scaleX, scaleY);


        //Coins
        int nCoins = 0;
        float coinX, coinY;

        while (nCoins < 1)
        {
            coinX = Random.Range(-deltaBuildings/2, deltaBuildings/2);
            coinY = Random.Range(-4.8f, 1.8f);

            //make sure the coin does not spawn inside a building
            if (!(coinY < scaleY - 5 + .25 && coinX >= -scaleX / 2 - .25 && coinX <= scaleX / 2 + .25))
            {
                Instantiate(coinPrototype, new Vector2(x + coinX, coinY), Quaternion.identity);
                nCoins++;
            }
        }
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = "Score: " + score;
        sound.PlayOneShot(coinCollect);
    }

    public void SetHighScore()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            if(score > PlayerPrefs.GetInt("highScore")){
                PlayerPrefs.SetInt("highScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }


    public void PlayAgain()
    {
        SceneManager.LoadScene("LoadingScene");
    }


    public void endGame()
    {
        Application.Quit();
    }
}
