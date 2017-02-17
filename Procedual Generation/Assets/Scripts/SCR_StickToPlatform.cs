using UnityEngine;
using System.Collections;

public class SCR_StickToPlatform : MonoBehaviour {

	private GameObject target = null;
	private Vector3 offset;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (target != null) {
			target.transform.position = target.transform.position + offset;
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		target = col.gameObject;
		offset = target.transform.position - col.transform.position;
		//Debug.Log ("Stick");
	}

	void OnTriggerExit2D(Collider2D col)
	{
		target = null;
	}
}
