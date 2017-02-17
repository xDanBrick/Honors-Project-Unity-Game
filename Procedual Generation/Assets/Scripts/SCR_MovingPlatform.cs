using UnityEngine;
using System.Collections;

public class SCR_MovingPlatform : SCR_LevelChunk {

	protected override void AddComponents(GameObject platform, float platformSeed)
	{
		if (platformSeed > 3.0f && platformSeed < 5.0f) 
		{
			platform.AddComponent<MoveObjectX> ();
		} 
		else if (platformSeed > 5.0f && platformSeed < 7.0f)
		{
			platform.AddComponent<MoveObjectY> ();
		} 
		else if (platformSeed > 8.0f) 
		{
			platform.AddComponent<DisapearOnTouch> ();
		} 
	}
}
