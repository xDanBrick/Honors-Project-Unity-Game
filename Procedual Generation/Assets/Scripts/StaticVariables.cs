using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StaticVariables 
{
	private static int levelNumber = 0;
	public static float spawnX = -5.0f;
	public static bool[] levelCompleted = new bool[5]{false, false, false, false, false};
	public static int levelDifficulty = 1;
	public static int LevelNumber()
	{
		return levelNumber;
	}
	public static void LoadLevel(int num)
	{
		SceneManager.LoadScene (1);
		levelNumber = num;
	}
}
