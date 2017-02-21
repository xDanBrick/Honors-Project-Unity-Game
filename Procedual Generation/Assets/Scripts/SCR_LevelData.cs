using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainLevelSelectData
{
	public static string difficuly = "";
	public static bool[] levelCompleted = new bool[100];
}

public class LevelData
{
	public static float timer = 0.0f;
	public static float spawnX = -50.0f;
	public static int deaths = 0;
	public static int levelDifficulty = 1;
	public static int levelNumber = 1;
	public static float floorPosition = 0.0f;

	public static void KillPlayer()
	{
		deaths++;
		SceneManager.LoadScene ("Main");
	}

	public static void ResetData()
	{
		deaths = 0;
		timer = 0.0f;
		spawnX = -50.0f;
	}
}

public class PlayerData
{
	public static bool isOnLift = false;

}

public class ProceduralGenerator
{
	public static float worldSeed = 5.193649f;
	public static float GenerateSeed(float seed, int itteratorIndex)
	{
		float newSeed = seed * worldSeed;
		for (int i = 0; i < itteratorIndex; i++)
		{
			newSeed = Mathf.PerlinNoise (newSeed, newSeed);
		}
		return newSeed;
	}
}
