using UnityEngine;
using System.Collections;

public class SCR_PlatformComponent : MonoBehaviour {

	protected float seed = 0.0f;
	protected int difficulty = 0;
	protected float probablityScaler = 1.0f;
	// Use this for initialization
	void Start () {
		difficulty = LevelData.levelDifficulty;
	}

	public float ProbablityScaler(){
		return probablityScaler;
	}

	protected virtual void InitVariables(){}

	public void SetVariables(float platformSeed)
	{
		seed = platformSeed;
		InitVariables ();
	}
}
