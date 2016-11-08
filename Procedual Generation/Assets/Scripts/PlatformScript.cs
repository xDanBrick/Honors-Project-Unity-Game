using UnityEngine; 
using System.Collections;

public class PlatformScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}

	public void SetPlatform(float seed, int difficulty)
	{
		float gapScaler = 0.5f + (0.1f * difficulty);
		float platformScaler = 1.5f - (0.1f * difficulty);

		int size = Mathf.CeilToInt (seed * platformScaler);
		transform.localScale = (new Vector3 ((float)size, 1.0f, 1.0f));

		float platformSeed = seed;
		bool loopComplete = false;
		bool[] componentAdded = new bool[4];

		while (!loopComplete) {
			if (platformSeed > 0.0f && platformSeed < 3.0f && !componentAdded[0]) 
			{
				gameObject.AddComponent<MoveObjectX> ();
				componentAdded [0] = true;
			} 
			else if (platformSeed > 3.0f && platformSeed < 6.0f && !componentAdded[1])
			{
				gameObject.AddComponent<MoveObjectY> ();
				componentAdded [1] = true;
			} 
			else if (platformSeed > 6.0f && platformSeed < 9.0f && !componentAdded[2]) {
				//gameObject.AddComponent<MoveObjectX> ();
				componentAdded [2] = true;
			} 
			else if (platformSeed > 9.0f && !componentAdded[3]) {
				gameObject.AddComponent<SpinObject> ();
				componentAdded [3] = true;
			}

			if (platformSeed > 5.0f) {
				loopComplete = true;
				Debug.Log (platformSeed);
			} 
			else 
			{
				platformSeed = Mathf.PerlinNoise (platformSeed, 2.35f) * 10.0f;
			}
		}
	}

	void ScaleDificulty(int difficulty)
	{

	}

	// Update is called once per frame
	void Update () {
	}
}
