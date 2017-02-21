﻿using UnityEngine;
using System.Collections;

public class SCR_DisapearOnTouch : SCR_PlatformComponent {

	float timer = 0;
	bool collided = false;
	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer> ().color = new Color(0.5f, 0.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		//If the player has collided
		if (collided) 
		{
			timer += Time.deltaTime;
			//If there has been more than a second
			if (timer > 1.0f) {
				for (int i = 0; i < transform.childCount; i++) {
					transform.GetChild (i).SetParent (null);
				}
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