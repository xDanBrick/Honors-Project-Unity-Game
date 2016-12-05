using UnityEngine;
using System.Collections;

public class DisapearOnTouch : MonoBehaviour {

	float timer = 0;
	bool collided = false;
	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer> ().color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
		//If the player has collided
		if (collided) 
		{
			timer += Time.deltaTime;
			//If there has been more than a second
			if (timer > 1.0f) {
				Destroy (gameObject);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") {
			collided = true;
		}
	}
}
