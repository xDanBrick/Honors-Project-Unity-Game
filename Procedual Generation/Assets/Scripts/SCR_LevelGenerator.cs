using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SCR_LevelGenerator : SCR_Generator {
	[SerializeField] private float worldSeed = 5.2463f;
	//[SerializeField] [Range(1, 10)] private int difficulty;
	float gapScaler = 0.5f;
	float platformScaler = 1.5f;
	float levelSeed = 0.0f;
	int floorCounter = 0;
	bool generateProcedually = true;

	void Start () {
		//GenerateLevel ();
		if (generateProcedually) {
			float levelSeed = ProceduralGenerator.GenerateSeed(ProceduralGenerator.worldSeed, LevelData.levelNumber);
			GenerateProcedurally (worldSeed, transform.position, new Vector3 (150.0f, 40.0f, 1.0f));
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void GenerateFloor(Vector2 position, SCR_SafeZone.TYPE startType, SCR_SafeZone.TYPE endType)
	{
		floorCounter++;
		GameObject floor = new GameObject ("Floor " + floorCounter.ToString ());
		SCR_FloorGenerator floorGenerator = (SCR_FloorGenerator)floor.AddComponent<SCR_FloorGenerator> ();
		float floorSeed = ProceduralGenerator.GenerateSeed(seed, floorCounter);
		floorGenerator.GenerateProcedurally (floorSeed, new Vector3 (position.x, position.y), new Vector3(150.0f, 20.0f));
		floorGenerator.GenerateZones (startType, endType);
		floor.transform.SetParent (transform);
	}

	protected override void Generate()
	{
		
		GenerateFloor (new Vector2(0.0f, -10.0f), SCR_SafeZone.TYPE.CHECKPOINT, SCR_SafeZone.TYPE.ELEVATOR);
		GenerateFloor (new Vector2(0.0f, 10.0f), SCR_SafeZone.TYPE.END, SCR_SafeZone.TYPE.ELEVATOR_END);
	}
}

