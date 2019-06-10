using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    private float mapX = 40f;
    private float mapY = 30f;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    public float MapX
    {
        get
        {
            return mapX;
        }

        set
        {
            mapX = value;
        }
    }

    public float MapY
    {
        get
        {
            return mapY;
        }

        set
        {
            mapY = value;
        }
    }

    public float MinX
    {
        get
        {
            return minX;
        }

        set
        {
            minX = value;
        }
    }

    public float MaxX
    {
        get
        {
            return maxX;
        }

        set
        {
            maxX = value;
        }
    }

    public float MinY
    {
        get
        {
            return minY;
        }

        set
        {
            minY = value;
        }
    }

    public float MaxY
    {
        get
        {
            return maxY;
        }

        set
        {
            maxY = value;
        }
    }

    private void Start()
    {
        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        // Calculations assume map is position at the origin
        MinX = horzExtent - MapX / 2;
        MaxX = MapX / 2 - horzExtent;
        MinY = vertExtent - MapY / 2;
        MaxY = MapY / 2 - vertExtent;
    }
}
