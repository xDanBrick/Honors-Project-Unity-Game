using UnityEngine; 
using System.Collections;

public class PlatformScript : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			col.transform.SetParent (transform);
		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			col.transform.SetParent (null);
			//col.gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
		}
	}
}
