using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MSMScript : MonoBehaviour
{
    public AircraftScript aircraftPrototype;
    public BuildingScript buildingPrototype;
    public CoinScript coinPrototype;
    public cameraScript cam;
    public AudioClip coinCollect;
    public AudioSource audio;
    Transform camTransform;
    float lastCamXb = 0;
    float lastCamXa = 0;
    float camX;
    public int deltaBuildings;
    public int deltaAircraft;
    public Text scoreText;
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        camTransform = cam.GetComponent<Transform>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        camX = camTransform.position.x;
        if(camX > lastCamXb + deltaBuildings)
        {
            SpawnBuildingAndCoins((int)camX + 14);
            lastCamXb = camX;
        }
        if (camX > lastCamXa + deltaAircraft)
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

        while (nCoins < 3)
        {
            coinX = Random.Range(-deltaBuildings/2, deltaBuildings/2);
            coinY = Random.Range(-4.9f, 1.9f);

            if (!(coinY < scaleY - 5 + .2 && coinX >= -scaleX / 2 - .2 && coinX <= scaleX / 2 + .2))
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
        audio.PlayOneShot(coinCollect);
    }

}
