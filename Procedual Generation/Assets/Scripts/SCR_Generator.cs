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

	protected float GetRightEdge(){
		return transform.position.x + (scale.x * 0.5f);
	}

	protected float GetLeftEdge(){
		return transform.position.x - (scale.x * 0.5f);
	}

	protected float GetTopEdge(){
		return transform.position.y + (scale.y * 0.5f);
	}

	protected float GetBottomEdge(){
		return transform.position.y - (scale.y * 0.5f);
	}

	//Draws the box around the chunk in editor
	void OnDrawGizmos()
	{
		Gizmos.DrawWireCube (transform.position, scale);
	}
}
