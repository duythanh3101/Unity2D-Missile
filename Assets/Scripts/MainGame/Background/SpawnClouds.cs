using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClouds : MonoBehaviour
{
    private MapGenerator map;

    [SerializeField]
    private GameObject[] Clouds;

    [SerializeField]
    private Transform CloudParent;

	// Use this for initialization
	void Start ()
    {
        map = GetComponent<MapGenerator>();

        SpawnRandomCloud();
	}

    //devide the map by 40 rectangle has size 5x6
    private void SpawnRandomCloud()
    {
        float sizeX = -map.MapX / 2;
        float sizeY = -map.MapY / 2;

        //8x15
        float vertical = 3.75f;
        float horizontal = 5f;

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                float randomX = Random.Range(0, horizontal);
                float randomY = Random.Range(0, vertical);

                int CloudIndex = RandomCloud();
                Instantiate(Clouds[CloudIndex], new Vector3(sizeX + randomX, sizeY + randomY, 0), Quaternion.identity, CloudParent);

                sizeX += horizontal;
            }
            sizeY = sizeY + vertical;
            sizeX = -map.MapX / 2;
        }

    }

    private int RandomCloud()
    {
        int random = Random.Range(0, Clouds.Length);
        return random;
    }
}
