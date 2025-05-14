using UnityEngine;
using System.Collections.Generic;
using System;

public class TextureToLevel : MonoBehaviour
{
    [SerializeField] private List<ColorToPrefab> mappings = new List<ColorToPrefab>();
    [SerializeField] private Texture2D map;
    [SerializeField] private float offsetX = -14f;
    [SerializeField] private float offsetY = -5f;
    [SerializeField] private float colorTolerance = 0.01f; // For approximate color matching

    private void Start()
    {
        if (map == null)
        {
            Debug.LogError("Map texture is not assigned!");
            return;
        }

        ReadTexture();
    }

    private void ReadTexture()
    {
        int rows = map.height;
        int cols = map.width;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                InstantiatePrefab(r, c);
            }
        }
    }

    private void InstantiatePrefab(int r, int c)
    {
        Color pixelColor = map.GetPixel(c, r);

        // Skip transparent pixels
        if (pixelColor.a < 0.1f)
            return;

        foreach (ColorToPrefab pair in mappings)
        {
            if (ColorsEqual(pixelColor, pair.color, colorTolerance))
            {
                Vector2 pos = new Vector2(c + offsetX, r + offsetY);
                Instantiate(pair.prefab, pos, Quaternion.identity, transform);
                break; // Exit early if a match is found
            }
        }
    }

    // Helper method for approximate color comparison
    private bool ColorsEqual(Color a, Color b, float tolerance)
    {
        return Mathf.Abs(a.r - b.r) < tolerance &&
               Mathf.Abs(a.g - b.g) < tolerance &&
               Mathf.Abs(a.b - b.b) < tolerance &&
               Mathf.Abs(a.a - b.a) < tolerance;
    }
}

[Serializable]
public class ColorToPrefab
{
    public Color color;
    public GameObject prefab;
}