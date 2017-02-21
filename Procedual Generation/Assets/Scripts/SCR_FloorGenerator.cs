using UnityEngine;
using System.Collections;

public class SCR_FloorGenerator : SCR_Generator {

	int chunkCounter = 0;
	Transform edge, safeZone;
	float currentX = 0.0f;
	float size = 0.0f;
	GameObject backgroundsParent;

	void Start()
	{
		
	}

	private GameObject GenerateChunk(Vector2 position, Vector2 size)
	{
		chunkCounter++;
		GameObject chunk = new GameObject ("Chunk " + chunkCounter.ToString());
		SCR_LevelChunk levelChunk = (SCR_ChaosChunk)chunk.AddComponent<SCR_ChaosChunk>();

		float chunkSeed = ProceduralGenerator.GenerateSeed (seed, chunkCounter);
		levelChunk.GenerateProcedurally (chunkSeed, new Vector3 (position.x, position.y), new Vector3 (size.x, size.y));
		levelChunk.transform.SetParent (transform);
		return chunk;
	}

	protected override void Generate()
	{
		edge = GameObject.Find ("Edge").transform;
		safeZone = GameObject.Find ("Safe Zone").transform;

		GameObject backgrounds = new GameObject ("Backgrounds");
		backgrounds.transform.SetParent (transform);
		Transform background = GameObject.Find ("Background").transform;
		for (int i = 0; i < (scale.x / 50.0f); i++) {
			Transform backgroundCopy = (Transform)Instantiate(background, new Vector3(GetLeftEdge() + (35.5f * i) + (edge.localScale.x * 1.5f), transform.position.y), transform.rotation);
			backgroundCopy.SetParent (backgrounds.transform);
		}

		//Add Left Edge
		GenerateEdge (new Vector3(GetLeftEdge() + (edge.localScale.x * 0.5f), transform.position.y), edge.localScale);
		GenerateEdge (new Vector3(GetRightEdge() - (edge.localScale.x * 0.5f), transform.position.y), edge.localScale);

		//Add Chunks
		int chunkCount = 2;
		int checkPointsCount = 1;

		//the currentx is the rightX of left edge
		currentX = (transform.position.x - (scale.x * 0.5f) + edge.localScale.x + (safeZone.localScale.x * 0.5f)) / 2.0f;

		//The size of the chunk is the leftX of the endZone - he currentX 
		float edgesWidth = edge.localScale.x * 2.0f;
		float safeZonesWidth = (safeZone.localScale.x * (2.0f + checkPointsCount));
		size = (scale.x - edgesWidth - safeZonesWidth) / 2;


		for (int i = 0; i < chunkCount; i++) {
			GameObject chunk = GenerateChunk (new Vector2(currentX, transform.position.y), new Vector2(size, 20.0f));
			currentX += size + safeZone.localScale.x;
		}
	}

	//Generates the start checkpoint and end zones for the floor
	public void GenerateZones(SCR_SafeZone.TYPE startType, SCR_SafeZone.TYPE endType)
	{
		GameObject zones = new GameObject ("Zones");
		zones.transform.SetParent (transform);
		//Add start zone
		GenerateZone(transform.position.x - (scale.x * 0.5f) + edge.localScale.x + (safeZone.localScale.x * 0.5f), startType);

		//Add end zone
		GenerateZone(transform.position.x, SCR_SafeZone.TYPE.CHECKPOINT);

		//Add checkpoint
		GenerateZone(transform.position.x + (scale.x * 0.5f) - edge.localScale.x - (safeZone.localScale.x * 0.5f), endType);

		float topEdgeX = transform.position.x + (safeZone.localScale.x * 0.5f);
		float topEdgeSize = scale.x - safeZone.localScale.x - (edge.localScale.x * 2.0f);

		if (startType == SCR_SafeZone.TYPE.CHECKPOINT || startType == SCR_SafeZone.TYPE.ELEVATOR_END
			|| startType == SCR_SafeZone.TYPE.START) {
			topEdgeX = transform.position.x - (safeZone.localScale.x * 0.5f);
		}
		if (startType == SCR_SafeZone.TYPE.END || endType == SCR_SafeZone.TYPE.END) {
			topEdgeSize = scale.x - (edge.localScale.x * 2.0f);
			topEdgeX = transform.position.x;
		}
		GenerateEdge (new Vector3(topEdgeX, GetTopEdge() - (3.0f)), new Vector3(topEdgeSize, 6.0f));
	}

	private void GenerateZone(float x, SCR_SafeZone.TYPE type)
	{
		Transform zone = (Transform)Instantiate (safeZone, new Vector3 (x, transform.position.y - (safeZone.localScale.y * 0.5f) + 3.0f), transform.rotation);
		zone.GetComponent<SCR_SafeZone> ().SetType (type);
		zone.SetParent (transform);
	}

	private void GenerateEdge (Vector3 position, Vector3 size)
	{
		Transform newEdge = (Transform)Instantiate (edge, position, transform.rotation);
		newEdge.localScale = size;
	}
}
