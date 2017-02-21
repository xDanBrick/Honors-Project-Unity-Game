using UnityEngine;
using System.Collections;

public class SCR_FadingPlatform : SCR_PlatformComponent {

	float alpha = 1.0f;
	float incremenet = -0.005f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (alpha < 0.25f && incremenet == -0.005f) {
			GetComponent<BoxCollider2D> ().enabled = false;
		}
		if (alpha > 0.25f && incremenet == 0.005f) {
			GetComponent<BoxCollider2D> ().enabled = true;
		}
		alpha += incremenet;
		SpriteRenderer renderer = GetComponent<SpriteRenderer> ();
		if (alpha < 0.0f || alpha > 1.0f) {
			incremenet *= -1.0f;
		}
		renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, alpha); 
	}
}
