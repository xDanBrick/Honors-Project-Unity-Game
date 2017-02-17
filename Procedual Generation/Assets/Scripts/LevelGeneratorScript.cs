using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGeneratorScript : MonoBehaviour {

	//length = 11 ( 7 - 11 ) ( 0 - 7 )
	//height = 4  ( 1 - 4  ) ( 0 - 1 )
	//highest with max length = 7
	//futherest with max height = 1

	[SerializeField] [Range(40, 100)] private int gridWidth = 40;
	[SerializeField] [Range(10, 30)] private int gridheight = 10;
	[SerializeField] private float worldSeed = 5.2463f;
	//[SerializeField] [Range(1, 10)] private int difficulty;



	float gapScaler = 0.5f;
	float platformScaler = 1.5f;

	void Start () {
		GenerateLevel ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private void GeneratePlatforms(float levelSeed, float start, float end)
	{
		GameObject chunk = new GameObject ("Chunk 1");
		chunk.transform.position = new Vector3(start, -3.0f, 0.0f);
		chunk.transform.localScale = new Vector3(end - start, 20.0f, 1.0f);
		SCR_ChaosChunk levelChunk = (SCR_ChaosChunk)chunk.AddComponent<SCR_ChaosChunk>();
		levelChunk.Initialise (levelSeed, LevelData.levelDifficulty, start, end);
	}

	public void GenerateLevel()
	{
		//Generate level seed
		float levelSeed = GenerateLevelSeed(LevelData.levelNumber);

		Transform safeZone2;

		GameObject background = GameObject.Find ("Background");
		for (int i = 0; i < (200 / 20) - 1; i++) {
				Instantiate(background, new Vector3(background.transform.position.x + (28.6f * i), background.transform.position.y, 0.0f), transform.rotation);
		}

		//Start platform
		//safeZone1 = GenerateSafeZone (new Vector2 (-5.0f, -3.0f), SafeZoneScript.TYPE.START);

		//safeZone2 = GenerateSafeZone (new Vector2 (30.0f, -3.0f), SafeZoneScript.TYPE.CHECKPOINT);

		safeZone2 = GenerateSafeZone (new Vector2 ((gridWidth * 2.0f) + 1.5f, -3.0f), SafeZoneScript.TYPE.END);

		GameObject rightEdge = GameObject.Find ("Right Edge");
		float rightEdgeX = safeZone2.position.x + (safeZone2.localScale.x * 0.5f) + (rightEdge.transform.localScale.x * 0.5f);
		rightEdge.transform.position = new Vector3 (rightEdgeX, rightEdge.transform.position.y);

		GeneratePlatforms (levelSeed, 0.0f, gridWidth);
		GeneratePlatforms (levelSeed, gridWidth, gridWidth * 2.0f);
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
		GameObject zone = (GameObject)Instantiate (GameObject.Find("Safe Zone"), new Vector3 (position.x, position.y, 0.0f), transform.rotation);
		zone.GetComponent<SafeZoneScript> ().SetType (type);
		return zone.transform;
	}
}

