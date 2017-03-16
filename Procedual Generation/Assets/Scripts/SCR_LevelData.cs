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
	public static string sceneName = "SCN_MainLevel";
	public static string levelSelectName = "SCN_LevelSelect";
	public static float timer = 0.0f;
	public static int deaths = 0;
	public static int levelDifficulty = 1;
	public static int levelNumber = 1;
	public static float floorPosition = 0.0f;
	public static int checkPointCount = 0;
	public static int currentCheckPoint = 0;
	public static int floorCount = 15;
	public static void KillPlayer()
	{
		deaths++;
		checkPointCount = 0;
		SceneManager.LoadScene (sceneName);
	}

	public static void ResetData()
	{
		deaths = 0;
		timer = 0.0f;
		currentCheckPoint = 0;
		checkPointCount = 0;
	}

	public static void LoadLevel(int number, int difficulty, string name, string selectName)
	{
		levelDifficulty = difficulty;
		levelNumber = number;
		sceneName = name;
		levelSelectName = selectName;
		ResetData ();
		SceneManager.LoadScene (sceneName);
		GameObject.Find ("MenuMusic").GetComponent<AudioSource> ().Stop ();
		GameObject.Find ("MainMusic").GetComponent<AudioSource> ().Play ();
		PlayerData.direction = 1.0f;
	}

}

public class PlayerData
{
	public static float direction = 1.0f;
}

public class ProceduralGenerator
{
	public static float worldSeed = 8.854379f;
	public static float GenerateSeed(float seed, int itteratorIndex)
	{
		float newSeed = seed * worldSeed;
		for (int i = 2; i < itteratorIndex + 2; i++)
		{
			newSeed = Mathf.PerlinNoise (newSeed * 10.0f, newSeed * 10.0f);
		}
		return newSeed;
	}
}
