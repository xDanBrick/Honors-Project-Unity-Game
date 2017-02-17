using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SCR_SplashScreen : MonoBehaviour {

	[SerializeField] private float changeTime = 3.0f;
	private float timer = 0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > changeTime) {
			SceneManager.LoadScene (1);
		}
	}
}
