using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SCR_LevelButton : MonoBehaviour {

	private int levelNumber;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetNumber(int index)
	{
		levelNumber = index;
		transform.GetChild (0).GetComponent<Text> ().text = levelNumber.ToString ();
		//If the level has been complete
		if (MainLevelSelectData.levelCompleted [levelNumber]) {
			GetComponent<RawImage> ().color = Color.green;
		} else {
			GetComponent<RawImage> ().color = Color.white;
		}
	}

	public void LoadLevel()
	{
		LevelData.levelDifficulty = 1;
		LevelData.levelNumber = levelNumber;
		LevelData.ResetData ();
		SceneManager.LoadScene ("Main");
	}

	public void LoadLevel(int levelNumber, int difficulty)
	{
		LevelData.levelDifficulty = 1;
		LevelData.levelNumber = levelNumber;
		LevelData.ResetData ();
		SceneManager.LoadScene ("Main");
	}

	public void LoadLevel(string name)
	{
		LevelData.levelDifficulty = 1;
		LevelData.levelNumber = levelNumber;
		LevelData.ResetData ();
		SceneManager.LoadScene ("Main");
	}
}
