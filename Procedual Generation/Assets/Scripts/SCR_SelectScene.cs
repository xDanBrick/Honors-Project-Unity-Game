using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SCR_SelectScene : MonoBehaviour {

	public void SetMainDifficulty(int number)
	{

	}

	public void TestGenerate(float seed)
	{
		for (int i = 98; i < 200; i++) {
			Debug.Log(ProceduralGenerator.GenerateSeed(seed, i));
		}
	}

	public void Restart()
	{
		LevelData.KillPlayer ();
	}

	public void LoadScene(string name)
	{
		GameObject.Find ("MenuSound").GetComponent<AudioSource> ().Play ();
		SceneManager.LoadScene (name);
	}

	public void Quit()
	{
		Application.Quit ();
	}
}
