using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SCR_SafeZone : MonoBehaviour {

	public enum TYPE{START, CHECKPOINT, END, ELEVATOR, ELEVATOR_END};
	[SerializeField]private TYPE zoneType;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetType(TYPE type)
	{
		zoneType = type;
		if (type == TYPE.START) {
			GameObject.FindGameObjectWithTag ("Player").transform.position = transform.position;
			LevelData.floorPosition = transform.GetChild(0).position.y;
		}
		if (type == TYPE.ELEVATOR) {
			gameObject.AddComponent<SCR_MoveYOnContact> ();
		}
		if (type == TYPE.ELEVATOR_END) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
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
				GetComponent<SpriteRenderer> ().color = Color.yellow;
				//If the new spawn is further on than the last
				if (transform.position.x > LevelData.spawnPoint.x || transform.position.y > LevelData.spawnPoint.y)
				{
					//Sets the new spawn position
					LevelData.spawnPoint = transform.position;
				}
			}
		}
	}
}
