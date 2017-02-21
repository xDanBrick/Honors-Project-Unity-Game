using UnityEngine;
using System.Collections;

public class SCR_FallingObject : MonoBehaviour {

	Transform player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.position.x + 2 > transform.position.x) {
			GetComponent<Rigidbody2D> ().isKinematic = false;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0.0f, -10.0f);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") {
			LevelData.KillPlayer ();
		} 
		else if (col.gameObject.tag == "Platform") {
			Destroy (gameObject);
		}
	}
}
