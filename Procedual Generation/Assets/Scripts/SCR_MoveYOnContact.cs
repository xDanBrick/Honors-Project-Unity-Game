using UnityEngine;
using System.Collections;

public class SCR_MoveYOnContact : SCR_PlatformComponent {

	bool onPlatform = false;
	float startY = 0.0f;
	bool atTop = false;
	float timer = 0.0f;
	void Start()
	{
		startY = transform.position.y;
	}
	protected override void InitVariables(){
		//startY = transform.position.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (!atTop) {
			if (onPlatform == true) {
				timer += Time.deltaTime;
			}
			if (LevelData.floorPosition > startY + 20.0f) {
				PlayerData.direction *= -1.0f;
				atTop = true;
				return;
			}
			if (timer > 1.0f || LevelData.floorPosition > startY + 10.0f) {
				transform.parent.Translate (0.0f, 0.1f, 0.0f);
				LevelData.floorPosition = transform.position.y;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		//If the player has collided with the platform
		if (col.gameObject.tag == "Player") 
		{
			if (transform.position.y < col.transform.position.y) {
				
				onPlatform = true;
			}

		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		//If the player has left the platform
		if (col.gameObject.tag == "Player") 
		{
			onPlatform = false;
			timer = 0.0f;
		}
	}
}
