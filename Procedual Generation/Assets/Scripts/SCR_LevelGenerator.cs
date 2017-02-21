using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SCR_LevelGenerator : SCR_Generator {
	[SerializeField] private float worldSeed = 5.2463f;
	int floors = 10;
	const float floorHeight = 20.0f;
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
			GenerateProcedurally (worldSeed, transform.position, new Vector3 (150.0f, floorHeight * (float)floors));
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void GenerateFloor(Vector3 position, Vector3 size, SCR_SafeZone.TYPE startType, SCR_SafeZone.TYPE endType)
	{
		floorCounter++;
		GameObject floor = new GameObject ("Floor " + floorCounter.ToString ());
		SCR_FloorGenerator floorGenerator = (SCR_FloorGenerator)floor.AddComponent<SCR_FloorGenerator> ();
		float floorSeed = ProceduralGenerator.GenerateSeed(seed, floorCounter);
		floorGenerator.GenerateProcedurally (floorSeed, new Vector3 (position.x, position.y), size);
		floorGenerator.GenerateZones (startType, endType);
		floor.transform.SetParent (transform);
	}

	protected override void Generate()
	{
		SCR_SafeZone.TYPE startType = SCR_SafeZone.TYPE.START;
		SCR_SafeZone.TYPE endType = SCR_SafeZone.TYPE.ELEVATOR;

		//For all the floors
		for (int i = 0; i < floors; i++)
		{
			// If this is the final floor to be generated
			if (i + 1 == floors) {
				//If i is an even number
				if (i % 2 == 0) {
					startType = SCR_SafeZone.TYPE.END;
				} else {
					endType = SCR_SafeZone.TYPE.END;
				}
			}
			float y = GetBottomEdge() + (floorHeight * 0.5f) + (floorHeight * i);
			GenerateFloor (new Vector3(transform.position.x, y), new Vector3(150.0f, floorHeight), startType, endType);

			if (endType == SCR_SafeZone.TYPE.ELEVATOR) 
			{
				startType = SCR_SafeZone.TYPE.ELEVATOR;
				endType = SCR_SafeZone.TYPE.ELEVATOR_END;
			} 
			else 
			{
				startType = SCR_SafeZone.TYPE.ELEVATOR_END;
				endType = SCR_SafeZone.TYPE.ELEVATOR;
			}
		}
	}
}

