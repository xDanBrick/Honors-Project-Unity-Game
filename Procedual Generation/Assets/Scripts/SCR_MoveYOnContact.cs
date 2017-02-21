using UnityEngine;
using System.Collections;

public class SCR_MoveYOnContact : SCR_PlatformComponent {

	bool onPlatform = false;
	float startY = 0.0f;
	protected override void InitVariables(){
		startY = transform.position.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (onPlatform) {
		} 
	}

	void OnCollisionStay2D(Collision2D col)
	{
		//If the player has collided with the platform
		if (col.gameObject.tag == "Player") 
		{
			if (transform.position.y >= 20.0f + (transform.localScale.y * 0.5f)) {
				GetComponent<Rigidbody2D> ().velocity = new Vector3 (0.0f, 0.0f);
				return;
			}
			onPlatform = true;
			LevelData.floorPosition = transform.position.y - (transform.localScale.y * 0.5f);
			Debug.Log (LevelData.floorPosition);
			GetComponent<Rigidbody2D> ().velocity = new Vector3 (0.0f, 2.0f);
		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		//If the player has left the platform
		if (col.gameObject.tag == "Player") 
		{
			onPlatform = false;
			PlayerData.isOnLift = false;
			//GetComponent<Rigidbody2D> ().velocity = new Vector3 (0.0f, 2.0f);
			GetComponent<Rigidbody2D> ().velocity = new Vector3 (0.0f, 0.0f);
		}
	}
}
