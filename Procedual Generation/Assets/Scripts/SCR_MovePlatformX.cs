using UnityEngine;
using System.Collections;

public class SCR_MovePlatformX : SCR_PlatformComponent {

	private float startX = 0.0f;
	private float moveDistance = 0.0f;
	float speed = 0.0f;
	float delay = 0.0f;
	float timer = 0.0f;

	protected override void InitVariables(){
		startX = transform.position.x;
		delay += (7.5f / seed);
		moveDistance = 3.0f;
		speed = 0.05f;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (timer < delay) {
			timer += Time.deltaTime;
		} 
		else {
			//Moves the platform right to left
			if (transform.position.x > startX + moveDistance || transform.position.x < startX) {
				speed *= -1.0f;
			}
			transform.Translate (new Vector3 (speed, 0.0f));
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		//If the player has collided with the platform
		if (col.gameObject.tag == "Player") 
		{
			col.transform.SetParent (gameObject.transform);
		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		//If the player has left the platform
		if (col.gameObject.tag == "Player") 
		{
			col.transform.SetParent (null);
		}
	}
}
