using UnityEngine;
using System.Collections;

public class SCR_LevelChunk : SCR_Generator {

	private const float maxJumpWidth = 10.0f;
	protected float currentX = 0.0f;
	protected int platformCount = 0;
	protected int gapCount = 0;
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

	protected float EndPosition()
	{
		return transform.position.x + (scale.x * 0.5f);
	}

	protected override void Generate()
	{
		//Set variables
		seed *= 10.0f;
		OnChunkCreate ();

		currentX = transform.position.x - (scale.x * 0.5f);

		Transform fallingObject = GameObject.Find ("Falling Object").transform;
		float fallingObjectSeed = Mathf.PerlinNoise (seed, seed);
		for (int i = 0; i < Mathf.RoundToInt (fallingObjectSeed * 10.0f); i++) {
			Instantiate (fallingObject, new Vector3 (transform.position.x + (2.0f * i), transform.position.y - (scale.y * 0.5f) - fallingObject.localScale.y), transform.rotation);
		}

		while (currentX < EndPosition()) {
			//Add Platform
			GeneratePlatform ();
			//Add Gap
			GenerateGap ();
		}
		Transform zone = GameObject.Find ("Kill Plane").transform;
		Transform killZone = (Transform)Instantiate (zone, new Vector3 ( transform.position.x, transform.position.y-  (scale.y * 0.5f) + (zone.localScale.y * 0.5f)), transform.rotation);
		killZone.localScale = new Vector3 (scale.x, 1.0f, 1.0f);
		killZone.SetParent (transform);
	}
	//Generate a platform
	void GeneratePlatform()
	{
		//Increment the platform count
		platformCount++;

		//Generate platform seed
		float platformSeed = ProceduralGenerator.GenerateSeed(seed, platformCount) * 10.0f;

		//Place Platform
		Transform platform = GameObject.Find ("Platform").transform;
		Transform newPlatform = (Transform)Instantiate(platform, new Vector3 (currentX, (transform.position.y - 10) + (platform.localScale.y * 0.5f) + 1.0f) , transform.rotation);

		//Sets the platform scaler
		float platformScaler = 1.5f - (0.1f * LevelData.levelDifficulty);

		//Scales the platform
		float size = platformSeed * platformScaler;
		if (currentX + size < EndPosition()) {
			//Adds an effect to the platform
			AddComponents (newPlatform.gameObject, platformSeed);
		} 
		else 
		{
			size -= (currentX + size) - EndPosition();
		}
		newPlatform.transform.localScale = (new Vector3 (size, 2.0f, 1.0f));
		newPlatform.transform.Translate (new Vector3 (size * 0.5f, 0.0f, 0.0f));
		newPlatform.transform.SetParent (transform);
		currentX += size;
	}

	//Generates the gap between the platforms
	void GenerateGap()
	{
		gapCount++;

		//For the size of the grid
		float gapScaler = 0.5f + (0.1f * LevelData.levelDifficulty);

		//Generate platform seed
		float gapSeed = ProceduralGenerator.GenerateSeed(seed, gapCount) * 10.0f;
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

	protected bool AddMovePlatformX(GameObject platform, float platformSeed)
	{
		if (currentX + 4.5f < EndPosition()) 
		{
			platform.AddComponent<SCR_MovePlatformX> ();
			currentX += 3.0f;
			return true;
		}
		return false;
	}

	protected bool AddMovePlatformY(GameObject platform, float platformSeed)
	{
		platform.AddComponent<SCR_MovePlatformY> ().SetVariables(platformSeed);
		return true;
	}

	protected bool AddDisapearingPlatform(GameObject platform, float platformSeed)
	{
		platform.AddComponent<SCR_DisapearOnTouch> ().SetVariables(platformSeed);
		return true;
	}

	protected bool AddSpinningPlatform(GameObject platform, float platformSeed)
	{
		if (platformCount > 1) {
			platform.AddComponent<SCR_RotatePlatform> ().SetVariables(platformSeed);
			return true;
		}
		return false;
	}

	protected bool AddFadingPlatform(GameObject platform, float platformSeed)
	{
		platform.AddComponent<SCR_FadingPlatform> ().SetVariables(platformSeed);
		return true;
	}

	protected bool AddBouncyPlatform(GameObject platform, float platformSeed)
	{
		platform.AddComponent<SCR_BouncyPlatform> ().SetVariables(platformSeed);
		currentX += 5.0f;
		return true;
	}
}
