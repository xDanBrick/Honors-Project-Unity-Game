using UnityEngine;
using System.Collections;

public class SpinObject : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Rotates platform
		transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f));
	}
}
