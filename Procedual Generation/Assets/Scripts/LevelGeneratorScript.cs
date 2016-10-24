using UnityEngine;
using System.Collections;

public class LevelGeneratorScript : MonoBehaviour {

	[SerializeField] private GameObject platform;
	[SerializeField] private GameObject gridSquare;
	[SerializeField] [Range(1, 10)] private int difficulty;
	[SerializeField] [Range(10, 30)] private int gridWidth = 20;
	[SerializeField] [Range(10, 30)] private int gridheight = 10;
	[SerializeField] private float seed = 543.6673f;
	float size;
	//length = 11 ( 7 - 11 ) ( 0 - 7 )
	//height = 4  ( 1 - 4  ) ( 0 - 1 )
	//highest with max length = 7
	//futherest with max height = 1
	// Use this for initialization
	void Start () {
		for (int i = 0; i < gridWidth; i++) {
			for(int j = -3; j < gridheight - 3; j++)
			{
				//GameObject ob = (GameObject)Instantiate (gridSquare, new Vector3 ((float)i, (float)j, 0.0f), transform.rotation);

			}
		}
		GameObject ob = (GameObject)Instantiate (gridSquare, new Vector3 (-2.0f, -3.0f, 0.0f), transform.rotation);
		//GameObject ob4 = (GameObject)Instantiate (gridSquare, new Vector3 (9.0f, -2.0f, 0.0f), transform.rotation);
		GameObject ob2 = (GameObject)Instantiate (gridSquare, new Vector3 (40.0f, -3.0f, 0.0f), transform.rotation);
		bool isDone = false;
		float startPoint = -1.0f;
		float gapScaler = 90.0f;
		while (!isDone) {
			float x = Mathf.PerlinNoise (seed * -1.0f, 3747.0f);
			if ((gapScaler - (x * 10.0f)) < 0.0f) {
				GameObject plat = (GameObject)Instantiate (gridSquare, new Vector3 (startPoint, -3.0f, 0.0f), transform.rotation);
				gapScaler -= 1.0f;

			} 
			else {
				gapScaler = 1.0f;
			}
			startPoint += 1.0f;
			if(startPoint > 38.0f)
			{
				isDone = true;
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void GeneratePlatforms()
	{
		float startX = -20.0f;
		bool isDone = false;
		int i = 1;
		while(!isDone)
		{
			float x = 0.0f;
			int width = Mathf.FloorToInt(x * 10.0f);
			int widthScaler = 7 - width;
			float distanceScaler = 15.0f - (float)widthScaler;

			if (x < 0.5f) {
				x *= 2.0f;
			}
			Debug.LogError (width);
			GameObject plat = (GameObject)Instantiate (platform, new Vector3 (startX + (x*25.0f), -3.0f, 0.0f), transform.rotation);
			plat.transform.localScale = new Vector3 ((float)width, plat.transform.localScale.y, plat.transform.localScale.z);
			startX += (x * distanceScaler);
			if (startX > 75.0f) {
				isDone = true;
			}
			i++;
		}
		Instantiate (platform, new Vector3 (75.0f, -3.0f, 0.0f), transform.rotation);
	}
}
