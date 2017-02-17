using UnityEngine;
using System.Collections;

public class MoveObjectX : MonoBehaviour {

	private float startX = 0.0f;
	private float moveDistance = 0.0f;
	float speed = 0.0f;
	// Use this for initialization
	void Start () {
		startX = transform.position.x;
		moveDistance = 3.0f;
		speed = 0.05f;
	}

	// Update is called once per frame
	void FixedUpdate () {
		//Moves the platform right to left
		if (transform.position.x > startX + moveDistance || transform.position.x < startX) {
			speed *= -1.0f;
		}
		GetComponent<Rigidbody2D> ().MovePosition(GetComponent<Rigidbody2D>().position + new Vector2 (speed, 0.0f));
		if (transform.childCount > 0) {
			//transform.GetChild(0).GetComponent<Rigidbody2D>().MovePosition(transform.GetChild(0).GetComponent<Rigidbody2D>().position + new Vector2(speed, 0.0f));
		}
	}
}
