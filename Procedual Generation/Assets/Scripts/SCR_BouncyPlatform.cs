using UnityEngine;
using System.Collections;

public class SCR_BouncyPlatform : SCR_PlatformComponent {

	// Use this for initialization
	void Start () {
		GetComponent<BoxCollider2D> ().sharedMaterial = GameObject.Find ("Bouncy Platform").GetComponent<BoxCollider2D> ().sharedMaterial;
		GetComponent<SpriteRenderer> ().color = new Color (0.0f, 0.0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
