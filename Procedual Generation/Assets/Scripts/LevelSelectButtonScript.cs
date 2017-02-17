using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectButtonScript : MonoBehaviour {

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
		if (MainLevelSelectData.levelCompleted [levelNumber - 1] == true) 
		{
			GetComponent<RawImage> ().color = Color.green;
		}
	}

	public void LoadLevel()
	{
		LevelData.levelDifficulty = 1;
		LevelData.levelNumber = levelNumber;
		LevelData.ResetData ();
		SceneManager.LoadScene ("Main");
	}
}
