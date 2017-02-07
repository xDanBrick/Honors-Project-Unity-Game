using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGeneratorScript : MonoBehaviour {

	//length = 11 ( 7 - 11 ) ( 0 - 7 )
	//height = 4  ( 1 - 4  ) ( 0 - 1 )
	//highest with max length = 7
	//futherest with max height = 1

	[SerializeField] private GameObject platform;
	[SerializeField] private GameObject safeZone;
	[SerializeField] [Range(40, 100)] private int gridWidth = 40;
	[SerializeField] [Range(10, 30)] private int gridheight = 10;
	[SerializeField] private float worldSeed = 5.2463f;
	//[SerializeField] [Range(1, 10)] private int difficulty;

	private const float maxJumpWidth = 10;

	float gapScaler = 0.5f;
	float platformScaler = 1.5f;
	private int difficulty = StaticVariables.levelDifficulty;

	void Start () {
		GenerateLevel ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private void GeneratePlatforms(float levelSeed, float start, float end)
	{
		//For the size of the grid
		float gapSize = 0.0f;
		while (start < end) {
			//Generate platform seed
			float platformSeed = Mathf.PerlinNoise (start * levelSeed, 2.35f) * 10.0f;

			//Place Platform
			GameObject plat = (GameObject)Instantiate (platform, new Vector3 (start + gapSize, -3.0f, 0.0f), transform.rotation);
			start = plat.GetComponent<PlatformScript> ().SetPlatform (platformSeed, difficulty, start, end);

			gapSize = (float)Mathf.CeilToInt (platformSeed * gapScaler);

			//If the gap is bigger than the max
			if (gapSize > maxJumpWidth) 
			{
				//Minus 2 until it isnt
				while (gapSize > maxJumpWidth) 
				{
					gapSize -= 2.0f;
				}
			}
		}
	}

	public void GenerateLevel()
	{
		//Sets the gap scaler
		gapScaler += (0.1f * difficulty);

		//Generate level seed
		float levelSeed = GenerateLevelSeed(StaticVariables.LevelNumber());

		Transform safeZone1, safeZone2;

		//Start platform
		safeZone1 = GenerateSafeZone (new Vector2 (-5.0f, -3.0f), SafeZoneScript.TYPE.START);

		//safeZone2 = GenerateSafeZone (new Vector2 (30.0f, -3.0f), SafeZoneScript.TYPE.CHECKPOINT);

		safeZone2 = GenerateSafeZone (new Vector2 (gridWidth, -3.0f), SafeZoneScript.TYPE.END);
		GeneratePlatforms (levelSeed, safeZone1.position.x + 1.5f, safeZone2.position.x - 1.5f);

		//End
		GenerateSafeZone (new Vector2 (gridWidth, -3.0f), SafeZoneScript.TYPE.END);

	}

	private float GenerateLevelSeed(int levelNum)
	{
		float seed = worldSeed;
		for (int i = 0; i < levelNum; i++)
		{
			seed = Mathf.PerlinNoise (seed, seed);
		}
		return seed;
	}

	Transform GenerateSafeZone(Vector2 position, SafeZoneScript.TYPE type)
	{
		GameObject zone = (GameObject)Instantiate (safeZone, new Vector3 (position.x, position.y, 0.0f), transform.rotation);
		zone.GetComponent<SafeZoneScript> ().SetType (type);
		return zone.transform;
	}
}

