using UnityEngine;
using System.Collections;

public class SCR_ChaosChunk : SCR_LevelChunk {

	protected override void AddComponents(GameObject platform, float platformSeed)
	{
		bool[] componentAdded = new bool[3];
		float componentSeed = Mathf.PerlinNoise (platformSeed, platformSeed) * 10.0f;
		Debug.Log (componentSeed);

		//while(componentSeed > 3.0f)
		//{
			if (componentSeed > 0.0f && componentSeed < 1.5f && !componentAdded[0]) 
			{
				AddFadingPlatform (platform, platformSeed);
			}
			else if (componentSeed > 1.5f && componentSeed < 3.0f && !componentAdded[1])
			{
				AddMovePlatformX (platform, platformSeed);
				componentAdded [1] = true;
			}
			else if (componentSeed > 3.0f && componentSeed < 4.5f && !componentAdded[2]) 
			{
				AddDisapearingPlatform (platform, platformSeed);
				componentAdded [2] = true;
			}
			else if (componentSeed > 4.5f && componentSeed < 6.0f && !componentAdded[2]) 
			{
				AddMovePlatformY (platform, platformSeed);
				componentAdded [2] = true;
			}
			else if (componentSeed > 6.0f && componentSeed < 7.5f && !componentAdded[2]) 
			{
				AddSpinningPlatform (platform, platformSeed);
				//componentAdded [2] = true;
			}
			else if (componentSeed > 7.5f && componentSeed < 9.0f && !componentAdded[2]) 
			{
				AddBouncyPlatform (platform, platformSeed);
				//componentAdded [2] = true;
			}
			if (componentAdded [0] && componentAdded [1] && componentAdded [2]) {
				//componentSeed = 0.0f;
			} 
			else 
			{
				//componentSeed = Mathf.PerlinNoise (componentSeed, 2.35f) * 10.0f;
			}
		//}
	}
}
