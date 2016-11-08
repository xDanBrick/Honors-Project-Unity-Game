using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGeneratorScript : MonoBehaviour {

	[SerializeField] private GameObject platform;
	[SerializeField] private GameObject safeZone;
	[SerializeField] [Range(1, 10)] private int difficulty;
	[SerializeField] [Range(40, 100)] private int gridWidth = 40;
	[SerializeField] [Range(10, 30)] private int gridheight = 10;
	[SerializeField] private float worldSeed = 5.2463f;
	private const int maxJumpWidth = 10;
	private Platform currentPlatform;

	float gapScaler = 0.5f;
	float platformScaler = 1.5f;
	//length = 11 ( 7 - 11 ) ( 0 - 7 )
	//height = 4  ( 1 - 4  ) ( 0 - 1 )
	//highest with max length = 7
	//futherest with max height = 1
	// Use this for initialization

	private class Platform
	{
		public Vector2 pos;
		public int width;
		public GameObject platform;
		public Platform(Platform plat1, int posX, float seed)
		{
			platform = (GameObject)Instantiate (platform, new Vector3 ((float)posX, -3.0f, 0.0f), new Quaternion());
			platform.GetComponent<PlatformScript> ().SetPlatform (seed, 8);
			//Add that size to the increment
			width += (int)platform.transform.localScale.x;
		}
	}


	void Start () {
		GenerateLevel ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void ScaleDifficulty()
	{
		gapScaler += (0.1f * difficulty);
		platformScaler -= (0.1f * difficulty);
	}
	
	private void GeneratePlatforms(float levelSeed, int start, int end)
	{
		//For the size of the grid
		int i = start + 5;
		while (i < end) {

			float platformSeed = Mathf.PerlinNoise ((float)i * levelSeed, 2.35f) * 10.0f;
			//Place Platform
			currentPlatform = new Platform(currentPlatform, i, platformSeed);
			i += currentPlatform.width;
			int gapSize = Mathf.CeilToInt (platformSeed * gapScaler);
			if (gapSize > maxJumpWidth) 
			{
				//Minus 3 until it isnt
				while (gapSize > maxJumpWidth) 
				{
					gapSize -= 3;
				}
			}
			i += gapSize;
		}
	}
	public void GenerateLevel()
	{
		ScaleDifficulty ();
		//Start
		float levelSeed = GenerateLevelSeed(StaticVariables.LevelNumber());
		GenerateSafeZone (new Vector2 (-5.0f, -3.0f), new Color (0.0f, 1.0f, 0.0f));
		//currentPlatform = new Platform(NULL, 
		//GeneratePlatforms (levelSeed, 0, 20);
		int gridIncrement = 0;
		while (gridIncrement < gridWidth) {
			float gapSeed = Mathf.PerlinNoise ((float)gridIncrement * levelSeed, 73.4625f);
			int gapSize = (30 + Mathf.CeilToInt (gapSeed * 10.0f));
			gridIncrement += gapSize;
			if (gridWidth < gridIncrement) {
				gridIncrement = gridWidth;
			} else {
				GenerateSafeZone (new Vector2 (gridIncrement, -3.0f), new Color (1.0f, 1.0f, 0.0f));
			}
			GeneratePlatforms (gapSeed, gridIncrement - gapSize, gridIncrement);
		}
		//End
		GenerateSafeZone (new Vector2 (gridWidth, -3.0f), new Color (0.0f, 1.0f, 0.0f));

	}

	private float GenerateLevelSeed(int levelNum)
	{
		float seed = worldSeed;
		for (int i = 0; i < levelNum; i++) {
			seed = Mathf.PerlinNoise (seed, 5.325f);
		}
		return seed;
	}

	void GenerateSafeZone(Vector2 position, Color color)
	{
		GameObject zone = (GameObject)Instantiate (safeZone, new Vector3 (position.x, position.y, 0.0f), transform.rotation);
		zone.GetComponent<SafeZoneScript> ().SetColor (color);
	}
}

