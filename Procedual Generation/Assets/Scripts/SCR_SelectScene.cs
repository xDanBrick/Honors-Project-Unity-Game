using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SCR_SelectScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadScene(int scene)
	{
		SceneManager.LoadScene (scene);
	}

	public void Quit()
	{
		Application.Quit ();
	}

	public void SelectDifficulty(int num)
	{
		string[] difficulty = new string[]{"Easy", "Medium", "Hard"};
		MainLevelSelectData.difficuly = difficulty [num];
		SceneManager.LoadScene (3);
	}
}
