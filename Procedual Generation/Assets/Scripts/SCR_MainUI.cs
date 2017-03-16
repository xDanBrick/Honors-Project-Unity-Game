using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SCR_MainUI : MonoBehaviour {

	private Text timerText, deathCounterText;
	// Use this for initialization
	void Start () {
		timerText = GameObject.Find ("Timer").GetComponent<Text> ();
		deathCounterText = GameObject.Find ("Deaths").GetComponent<Text> ();

	}
	
	// Update is called once per frame
	void Update () {
		LevelData.timer += Time.deltaTime;
		timerText.text = "Time " + LevelData.timer.ToString("F2");
		deathCounterText.text = "Deaths " + LevelData.deaths.ToString ();
	}
}
