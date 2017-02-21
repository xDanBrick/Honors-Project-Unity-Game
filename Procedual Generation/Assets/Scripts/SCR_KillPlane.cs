using UnityEngine;
using System.Collections;

public class SCR_KillPlane : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		
		if (collider.tag == "Player") {
			LevelData.KillPlayer ();
		}
	}
	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawCube (transform.position, transform.localScale);
	}
}
