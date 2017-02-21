using UnityEngine;
using System.Collections;

public class SCR_RotatePlatform : SCR_PlatformComponent {

	private float delay = 0.0f;
	private float timer = 0.0f;

	protected override void InitVariables(){
		delay += (7.5f / seed);
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (timer > delay) {
			transform.Rotate (new Vector3 (0.0f, 0.0f, 1.0f));
		} 
		else 
		{
			timer += Time.deltaTime;
		}
	}
}
