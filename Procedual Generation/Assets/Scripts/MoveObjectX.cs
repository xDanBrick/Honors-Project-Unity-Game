using UnityEngine;
using System.Collections;

public class MoveObjectX : MonoBehaviour {

	private float startX = 0.0f;
	private float moveDistance = 0.0f;
	float speed = 0.0f;
	// Use this for initialization
	void Start () {
		startX = transform.position.x;
		moveDistance = 3.0f;
		speed = 0.05f;

	}

	public void SetVariables(float seed, int difficulty)
	{
		moveDistance = 5.0f;
		speed = 0.1f;
	}

	// Update is called once per frame
	void Update () {
		//Moves the platform right to left
		transform.position = new Vector3 (transform.position.x + speed, transform.position.y, transform.position.z);
		if (transform.position.x > startX + moveDistance || transform.position.x < startX ) {
			speed *= -1.0f;
		} 
	}
}
