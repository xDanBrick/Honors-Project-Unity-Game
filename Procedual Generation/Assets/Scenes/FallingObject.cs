using UnityEngine;
using System.Collections;

public class FallingObject : MonoBehaviour {

	Transform player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.position.x + 2 > transform.position.x) {
			GetComponent<Rigidbody2D> ().isKinematic = false;
		}
	}
}
