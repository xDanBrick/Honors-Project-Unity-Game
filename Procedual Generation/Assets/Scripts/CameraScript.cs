﻿using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
		//Follow player
		transform.position = new Vector3(player.transform.position.x + 5.0f, transform.position.y, transform.position.z);
	}
}
