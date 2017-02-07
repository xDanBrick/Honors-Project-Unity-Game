using UnityEngine; 
using System.Collections;

public class PlatformScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}

	public float SetPlatform(float platformSeed, int difficulty, float start, float end)
	{
		//Sets the platform scaler
		float platformScaler = 1.5f - (0.1f * difficulty);

		//Scales the platform
		float size = platformSeed * platformScaler;
		transform.localScale = (new Vector3 (size, 1.0f, 1.0f));

		//Adds an effect to the platform
		AddComponents (platformSeed);

		//Checks the edges of the platform by the last and end
		CheckEdges(start, end);

		//Return the x value of the right edge of the platform
		return transform.position.x + (transform.localScale.x * 0.5f);
	}

	void AddComponents(float platformSeed)
	{
		if (platformSeed > 5.0f && platformSeed < 6.0f) 
		{
			gameObject.AddComponent<MoveObjectX> ();
		} 
		else if (platformSeed > 6.0f && platformSeed < 7.0f)
		{
			gameObject.AddComponent<MoveObjectY> ();
		} 
		else if (platformSeed > 7.0f && platformSeed < 8.0f) 
		{
			gameObject.AddComponent<DisapearOnTouch> ();
		} 
		else if (platformSeed > 8.0f) 
		{
			gameObject.AddComponent<SpinObject> ();
		}
	}

	void CheckEdges(float start, float end)
	{
		float halfScaleX = transform.localScale.x * 0.5f;

		//If the platform is overlapping the last platform
		if ((transform.position.x - halfScaleX) < start) 
		{
			float difference = start - (transform.position.x - halfScaleX) ;
			transform.localScale = new Vector3 (transform.localScale.x - difference, transform.localScale.y, transform.localScale.z);
			transform.position = new Vector3 (transform.position.x + (difference * 0.5f), transform.position.y, transform.position.z);
		}

		//If the platform is overlapping the end Platform
		if ((transform.position.x + halfScaleX) > end) 
		{
			float difference = (transform.position.x + halfScaleX) - end;
			transform.localScale = new Vector3 (transform.localScale.x - difference, transform.localScale.y, transform.localScale.z);
			transform.position = new Vector3 (transform.position.x - (difference * 0.5f), transform.position.y, transform.position.z);
		}
	}

	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") {
			col.transform.SetParent (transform);
		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") {
			col.transform.SetParent (null);
		}
	}
}
