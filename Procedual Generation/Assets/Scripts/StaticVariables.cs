using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainLevelSelectData
{
	public static string difficuly = "";
	public static bool[] levelCompleted = new bool[50];
}

public class LevelData
{
	public static float timer = 0.0f;
	public static float spawnX = 1.5f;
	public static int deaths = 0;
	public static int levelDifficulty = 1;
	public static int levelNumber = 1;

	public static void KillPlayer()
	{
		deaths++;
		SceneManager.LoadScene ("Main");
	}

	public static void ResetData()
	{
		deaths = 0;
		timer = 0.0f;
		spawnX = 1.5f;
	}
}
