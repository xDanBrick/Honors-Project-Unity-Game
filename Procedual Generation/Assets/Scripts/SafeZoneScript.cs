using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SafeZoneScript : MonoBehaviour {

	public enum TYPE{START, CHECKPOINT, END};
	private TYPE zoneType;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetType(TYPE type)
	{
		Color color;
		switch (type) 
		{
			case TYPE.START:
			{
				color = Color.white;
				break;
			}
			case TYPE.CHECKPOINT:
			{
				color = Color.yellow;
				break;
			}
			case TYPE.END:
			{
				color = Color.green;					
				break;
			}
			default:
			{
				color = Color.black;	
				break;
			}

		}
		//Sets the platform color
		transform.GetChild (0).GetComponent<SpriteRenderer> ().color = color;

		//Sets the background color to half the value of the platform color
		GetComponent<SpriteRenderer> ().color = new Color (color.r * 0.5f, color.g * 0.5f, color.b * 0.5f);
		zoneType = type;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			if (zoneType == TYPE.END) 
			{
				//Takes the player back to the level select screen
				MainLevelSelectData.levelCompleted[LevelData.levelNumber] = true;
				SceneManager.LoadScene("LevelSelect");

			} 
			else 
			{
				//If the new spawn is further on than the last
				if (transform.position.x > LevelData.spawnX)
				{
					//Sets the new spawn position
					LevelData.spawnX = transform.position.x;
				}
			}
		}
	}
}
