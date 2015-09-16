using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour {
     
    /// Sets the size of area level
	public int width;                   
	public int height;   
                       
    // Stores the seed the user will enter
	public string seed;
    // Tells whether a random map will be created or if a predefined seed will be used
	public bool useRandomSeed;

	[Range(0,100)]
	public int randomFillPercent;

	int [,] map;

    [SerializeField] private GameObject WinPlatform;
    [SerializeField] private GameObject blackCube;
    [SerializeField] private GameObject Player;


    void Start()
	{
		GenerateMap ();
	}

	void GenerateMap ()
	{
		map = new int[width,height];
		RandomFillMap ();
		GeneratePlanes();
	}

	void RandomFillMap()
	{
		if (useRandomSeed) 
		{
			seed = Random.Range(0,100).ToString();
		}

		System.Random pseudoRandom = new System.Random (seed.GetHashCode ());

		for (int x = 0; x < width; x++) 
		{
			for(int y = 0 ; y < height; y++)
			{
				map[x,y] = (pseudoRandom.Next(0,100) < randomFillPercent && x != 0 && y != 0 && x != width-1 && y != height-1 ) ? 1 : 0;
			}
		}
	}

	public void GeneratePlanes()
	{
		if (map != null) 
		{
			for(int x = 0; x < width; x++)
			{
				for(int y = 0 ; y < height; y ++)
				{
                    Vector3 pos = new Vector3(-width / 2 + x + .5f, 0, -height / 2 + y + .5f);

                    if (map[x, y] == 1)
                    {
                        blackCube = (GameObject) Instantiate (blackCube, new Vector3(pos.x, pos.y + .5f, pos.z), Quaternion.identity);
                    }
					if(x == 0 && y == 0)
                    {
                        Instantiate(Player,new Vector3 (pos.x, .5f,pos.z),Quaternion.identity);
                    }
                    if (x == width - 1 && y == height - 1)
                    {
                        WinPlatform = (GameObject) Instantiate (WinPlatform, new Vector3(pos.x, pos.y, pos.z),Quaternion.identity);
                    }
				}
			}
		}
	}
    
    public Vector3 PlayerPosition = new Vector3();
    public Vector3 ReturnPlayerPosition()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 pos = new Vector3(-width / 2 + x + .5f, 0, -height / 2 + y + .5f);

                if (x == 0 && y == 0)
                {
                    PlayerPosition = new Vector3(pos.x, .5f, pos.z);
                }
            }
        }
      return PlayerPosition;
    }
}
