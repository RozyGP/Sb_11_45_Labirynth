using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColorToPrefab[] colorMappings;
    public float offest = 5f;

    void GenerateTile(int x, int z)
    {
        Color pixelColor = map.GetPixel(x, z);

        if (pixelColor.a == 0)
            return;

        foreach(ColorToPrefab colorMapping in colorMappings)
        {
            if(colorMapping.color.Equals(pixelColor))
            {
                Vector3 position = new Vector3(x, 0, z) * offest;
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
            }
        }
    }

    public void GenerateLabirynth()
    {
        //map.width;
        //map.height;
        for(int z = 0; z < map.height; z++)
        {
            for(int x = 0; x < map.width; x++)
            {
                GenerateTile(x, z);
            }
        }
    }
}
