using UnityEngine;
using System.Collections;

public class level : MonoBehaviour
{
    public int levelWidth;
    public int levelHeight;
    private Color[] tileColors;

    public Transform GrassTile;
    public Color grassColor;

    public Texture2D levelTexture;

    // Use this for initialization
    void Start()
    {
        levelWidth = levelTexture.width;
        levelHeight = levelTexture.height;
        loadLevel();
    }

    // Update is called once per frame
    void Update()
    {


    }
    void loadLevel()
    {
        tileColors = new Color[levelWidth * levelHeight];
        tileColors = levelTexture.GetPixels();


        for (int y = 0; y < levelHeight; y++)
            for (int x = 0; x < levelWidth; x++)
            {
                if (tileColors[x + y * levelWidth] == grassColor)
                    Instantiate(GrassTile, new Vector3(x, y), Quaternion.identity);

            }
    }
}
