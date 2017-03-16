using UnityEngine;
using System.Collections;

public class SCR_MenuMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (GetComponent<AudioSource> ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
