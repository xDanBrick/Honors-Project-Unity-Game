using UnityEngine;
using System.Collections;

public class SCR_LevelChunk : MonoBehaviour {

	float seed = 0.0f;
	int difficulty = 0;
	protected float end = 0.0f;
	private const float maxJumpWidth = 10.0f;
	protected float currentX = 0.0f;
	protected int platformCount = 0;
	[SerializeField] int difficultyScaler = 0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Overrideable functions
	protected virtual void AddComponents(GameObject platform, float platformSeed){}
	protected virtual void OnChunkCreate(){}

	//Initialise the chunk
	public void Initialise(float levelSeed, int chunkDifficulty, float chunkStart, float chunkEnd)
	{
		//Set variables
		seed = Mathf.PerlinNoise (transform.position.x * levelSeed, 2.35f) * 10.0f;
		difficulty = chunkDifficulty;
		end = chunkEnd;
		OnChunkCreate ();

		//Add Checkpoint to chunk
		GameObject safeZone = GameObject.Find("Safe Zone");
		GameObject zone = (GameObject)Instantiate (safeZone, new Vector3 (transform.position.x + (safeZone.transform.localScale.x * 0.5f), -3.0f, 0.0f), transform.rotation);
		zone.GetComponent<SafeZoneScript> ().SetType (SafeZoneScript.TYPE.CHECKPOINT);
		currentX = zone.transform.position.x + (zone.transform.localScale.x * 0.5f);


		GameObject fallingObject = GameObject.Find ("Falling Object");
		float fallingObjectSeed = Mathf.PerlinNoise (seed, seed);
		for (int i = 0; i < Mathf.RoundToInt (fallingObjectSeed * 10.0f); i++) {
			Instantiate (fallingObject, new Vector3 (transform.position.x + (transform.localScale.x * fallingObjectSeed) + (i * 2), fallingObject.transform.position.y), transform.rotation);
		}

		while (currentX < end) {
			//Add Platform
			GeneratePlatform ();
			//Add Gap
			GenerateGap ();

		}
	}

	//Generate a platform
	void GeneratePlatform()
	{
		//Increment the platform count
		platformCount++;

		//Generate platform seed
		float platformSeed = Mathf.PerlinNoise (platformCount * seed, 2.35f) * 10.0f;

		//Place Platform
		GameObject newPlatform = (GameObject)Instantiate (GameObject.Find ("Platform"), new Vector3 (currentX, -3.0f, 0.0f), transform.rotation);

		//Sets the platform scaler
		float platformScaler = 1.5f - (0.1f * difficulty);

		//Scales the platform
		float size = platformSeed * platformScaler;
		if (currentX + size < end) {
			//Adds an effect to the platform
			AddComponents (newPlatform, platformSeed);
		} 
		else 
		{
			size -= (currentX + size) - end;
		}
		newPlatform.transform.localScale = (new Vector3 (size, 1.5f, 1.0f));
		newPlatform.transform.Translate (new Vector3 (size * 0.5f, 0.0f, 0.0f));
		currentX += size;
	}

	//Generates the gap between the platforms
	void GenerateGap()
	{
		//For the size of the grid
		float gapScaler = 0.5f + (0.1f * difficulty);

		//Generate platform seed
		float gapSeed = Mathf.PerlinNoise (currentX * seed, 2.35f) * 10.0f;
		float gapSize = gapSeed * gapScaler;

		//If the gap is bigger than the max
		if (gapSize > maxJumpWidth) 
		{
			//Minus 2 until it isnt
			while (gapSize > maxJumpWidth) 
			{
				gapSize -= 2.0f;
			}
		}
		currentX += gapSize;
	}

	//Draws the box around the chunk in editor
	void OnDrawGizmos()
	{
		Gizmos.DrawWireCube (transform.position + (transform.localScale / 2), transform.localScale);
	}
}
