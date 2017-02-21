using UnityEngine;
using System.Collections;

public class SCR_Generator : MonoBehaviour {


	protected Vector3 scale;
	protected float seed = 0.0f;

	public void GenerateProcedurally (float generatorSeed, Vector3 generatorPosition, Vector3 generatorScale)
	{
		seed = generatorSeed;
		transform.position = generatorPosition;
		scale = generatorScale;
		Generate ();
	}

	protected virtual void Generate()
	{

	}

	// Update is called once per frame
	void Update () {
	
	}

	//Draws the box around the chunk in editor
	void OnDrawGizmos()
	{
		Gizmos.DrawWireCube (transform.position, scale);
	}
}
