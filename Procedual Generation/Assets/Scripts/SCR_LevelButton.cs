using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SCR_LevelButton : MonoBehaviour {

	private int levelNumber;
	[SerializeField] private bool mainLevelSelect = false;

	public void SetNumber(int index)
	{
		levelNumber = index;
		transform.GetChild (1).GetComponent<Text> ().text = levelNumber.ToString ();
		//If the level has been complete
		if (MainLevelSelectData.levelCompleted [levelNumber]) {
			//GetComponent<RawImage> ().color = Color.green;
		} else {
			//GetComponent<RawImage> ().color = Color.white;
		}
	}

	public void LoadLevel()
	{
		LevelData.levelDifficulty = 1;
		LevelData.levelNumber = levelNumber;
		LevelData.ResetData ();
		SceneManager.LoadScene ("SCN_MainLevel");
		LevelData.LoadLevel (levelNumber, 1, "SCN_MainLevel", "SCN_LevelSelect");
	}

	public void SetFloors(int floors)
	{
		LevelData.floorCount = floors;
	}

	public void LoadLevel(int number)
	{
		LevelData.floorPosition = 0;
		LevelData.LoadLevel (number, 1, "SCN_MainLevel", "SCN_HonorsLevelSelect");
	}

	public void LoadNewLevel(string name)
	{
		LevelData.LoadLevel (levelNumber, 1, name, "SCN_HonorsLevelSelect");
	}
}
