using UnityEngine;
using System.Collections;

public class SCR_Camera : MonoBehaviour {

	Transform player;
	[SerializeField] float floorPosition = LevelData.floorPosition;
	[SerializeField] bool procedural = true;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		if (!procedural) {
			LevelData.floorPosition = floorPosition;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Follow player
		transform.position = new Vector3 (player.position.x + (5.0f * PlayerData.direction), LevelData.floorPosition + 7.0f, -10.0f);
	}
}
