using UnityEngine;
using System.Collections;

public class SafeZoneScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetColor(Color color)
	{
		GetComponent<SpriteRenderer> ().color = new Color (color.r * 0.5f, color.g * 0.5f, color.b * 0.5f);
		transform.GetChild (0).GetComponent<SpriteRenderer> ().color = color;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") {
			if (transform.position.x > StaticVariables.spawnX) {
				StaticVariables.spawnX = transform.position.x;
			}
		}
	}
}
