using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSMScript : MonoBehaviour
{
    public AircraftScript aircraftPrototype;
    public BuildingScript buildingPrototype;
    public CoinScript coinPrototype;

    // Start is called before the first frame update
    void Start()
    {
        for (int n = 0; n < 4; n++)
        {
            SpawnBuildingAndCoins(6 * n - 9);
        }

        for (int n = 0; n < 3; n++)
        {
            SpawnAircraftAndCoins(6 * n - 6);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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

        while (nCoins < 2)
        {
            coinX = Random.Range(-3, 3);
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
        float scaleY = Random.Range(2, 7);
        BuildingScript building = Instantiate(buildingPrototype, new Vector2(x, -5 + scaleY / 2), Quaternion.identity);
        Transform buildingForm = building.gameObject.GetComponent<Transform>();
        buildingForm.localScale = new Vector2(scaleX, scaleY);


        //Coins
        int nCoins = 0;
        float coinX, coinY;

        while (nCoins < 4)
        {
            coinX = Random.Range(-3, 3);
            coinY = Random.Range(-4.9f, 1.9f);

            if (!(coinY < scaleY - 5 + .2 && coinX >= -scaleX / 2 - .2 && coinX <= scaleX / 2 + .2))
            {
                Instantiate(coinPrototype, new Vector2(x + coinX, coinY), Quaternion.identity);
                nCoins++;
            }
        }
    }

    void SpawnCoins(int center, float width, float height)
    {
        int nCoins = 0;
        float x, y;

        while (nCoins < 4)
        {
            x = Random.Range(-3, 3);
            y = Random.Range(-4.9f, 4.9f);

            if (!(y < height - 5 + .2 && x >= -width / 2 - .2 && x <= width / 2 + .2))
            {
                Instantiate(coinPrototype, new Vector2(center + x, y), Quaternion.identity);
                nCoins++;
            }
        }
    }
}
