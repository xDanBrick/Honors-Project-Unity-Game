using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SelectScene : MonoBehaviour {

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
}
