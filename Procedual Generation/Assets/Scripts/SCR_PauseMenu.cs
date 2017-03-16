using UnityEngine;
using System.Collections;

public class SCR_PauseMenu : MonoBehaviour {

	private bool paused = false;

	// Use this for initialization
	void Start () {
	
	}

	public void SwitchPauseState()
	{
		paused = !paused;
		if (paused) {
			Time.timeScale = 0.0f;
		} else {
			Time.timeScale = 1.0f;
		}
		for (int i = 0; i < transform.childCount; i++) {
			transform.GetChild (i).gameObject.SetActive (paused);
		}
	}

	public void Restart()
	{
		LevelData.LoadLevel (LevelData.levelNumber, LevelData.levelDifficulty, LevelData.sceneName, LevelData.levelSelectName);
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return))
		{
			SwitchPauseState ();
		}
	}
}
