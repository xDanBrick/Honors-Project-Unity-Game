using UnityEngine;
using System.Collections;

public class SCR_ChaosChunk : SCR_LevelChunk {

	protected override void AddComponents(GameObject platform, float platformSeed)
	{
		bool[] componentAdded = new bool[3];
		float componentSeed = Mathf.PerlinNoise (platformSeed, 2.35f) * 10.0f;
		int increment = 0;

		//while(componentSeed > 3.0f)
		//{
			if (componentSeed > 3.0f && componentSeed < 5.0f && !componentAdded[0]) 
			{
				if (currentX + 4.5f < end) 
				{
					platform.AddComponent<MoveObjectX> ();
					currentX += 3.0f;
					componentAdded [0] = true;
				}
			}
			else if (componentSeed > 5.0f && componentSeed < 7.0f && !componentAdded[1])
			{
				platform.AddComponent<MoveObjectY> ();
				componentAdded [1] = true;
			}
			else if (componentSeed > 8.0f && !componentAdded[2]) 
			{
				platform.AddComponent<DisapearOnTouch> ();
				componentAdded [2] = true;
			}
			if (componentAdded [0] && componentAdded [1] && componentAdded [2]) {
				componentSeed = 0.0f;
			} 
			else 
			{
				componentSeed = Mathf.PerlinNoise (componentSeed, 2.35f) * 10.0f;
			}
		//}
	}
}
