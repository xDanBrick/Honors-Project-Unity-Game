using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelectButtonScript : MonoBehaviour {

	[SerializeField] private int levelNumber = 0;

	// Use this for initialization
	void Start () {
		//If the level has been complete
		if (StaticVariables.levelCompleted [levelNumber] == true) 
		{
			GetComponent<RawImage> ().color = Color.green;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
