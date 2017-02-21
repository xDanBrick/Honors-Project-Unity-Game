using UnityEngine;
using System.Collections;

public class SCR_Camera : MonoBehaviour {

	Transform player;
	float startY;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		startY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerData.isOnLift) {

		} else {

		}
		//Follow player
		transform.position = new Vector3 (player.position.x + 5.0f, LevelData.floorPosition + 8.5f - 20.0f, transform.position.z);
	}
}
