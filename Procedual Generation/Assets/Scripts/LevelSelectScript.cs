using UnityEngine;
using System.Collections;

public class LevelSelectScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetDifficulty(int difficulty)
	{
		StaticVariables.levelDifficulty = difficulty;
	}

	public void LoadLevel(int number)
	{
		StaticVariables.LoadLevel (number);
	}

}
