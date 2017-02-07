using UnityEngine;
using System.Collections;

public class MoveObjectY : MonoBehaviour {

	private float startY = 0.0f;
	private float moveDistance = 0.0f;
	float speed = 2.0f;
	// Use this for initialization
	void Start () {
		startY = transform.position.y;
		moveDistance = 3.0f;
		speed = 2.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Moves the platform Up and down
		//transform.position = new Vector3 (transform.position.x, transform.position.y + speed, transform.position.z);
		if (transform.position.y > startY+ moveDistance || transform.position.y < startY) {
			speed *= -1.0f;
		} 
		GetComponent<Rigidbody2D> ().velocity = new Vector3 (0.0f, speed, 0.0f);
	}
}
