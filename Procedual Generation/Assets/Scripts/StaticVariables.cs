using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StaticVariables 
{
	private static int levelNumber = 1;
	public static float spawnX = -5.0f;
	public static int LevelNumber()
	{
		return levelNumber;
	}
	public static void LoadLevel(int num)
	{
		SceneManager.LoadScene (2);
		levelNumber = num;
	}
}
