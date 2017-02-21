using UnityEngine;
using System.Collections;

public class SCR_MovePlatformY : SCR_PlatformComponent {

	private float startY = 0.0f;
	private float moveDistance = 3.0f;
	float speed = 2.0f;

	float timer = 0.0f;
	float delay = 0.0f;
	// Use this for initialization

	protected override void InitVariables(){
		startY = transform.position.y;
		delay += (7.5f / seed);
		float addPosition = moveDistance / seed;
		moveDistance = 3.0f;
		transform.position = new Vector3 (transform.position.x, transform.position.y + addPosition);
		if (seed > 5.0f) {
			speed *= -1.0f;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {


			//Moves the platform Up and down
			if (transform.position.y > startY + moveDistance || transform.position.y < startY) {
				speed *= -1.0f;
			}
			//transform.Translate (new Vector3 (0.0f, speed, 0.0f));
			GetComponent<Rigidbody2D> ().velocity = new Vector3 (0.0f, speed, 0.0f);
	}
}
