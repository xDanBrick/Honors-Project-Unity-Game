using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SCR_SafeZone : MonoBehaviour {

	public enum TYPE{START, CHECKPOINT, END, ELEVATOR, ELEVATOR_END, NONE};
	[SerializeField]private TYPE zoneType;
	int checkPointNumber = 0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetType(TYPE type)
	{
		zoneType = type;
		checkPointNumber = LevelData.checkPointCount;
		LevelData.checkPointCount++;
		if (LevelData.currentCheckPoint == checkPointNumber) 
		{
			if (type == TYPE.ELEVATOR) {
				transform.Translate (0.0f, 20.0f, 0.0f);
				type = TYPE.NONE;
			}
			GameObject.FindGameObjectWithTag ("Player").transform.position = transform.position;
			LevelData.floorPosition = transform.GetChild(0).position.y;
		}
		if (type == TYPE.ELEVATOR) {
			transform.GetChild(0).gameObject.AddComponent<SCR_MoveYOnContact> ();
		}
		if (type == TYPE.ELEVATOR_END) {
			Destroy (gameObject);
		}
		if (type == TYPE.CHECKPOINT) {
			transform.GetChild (0).SetParent (null);
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
				SceneManager.LoadScene(LevelData.levelSelectName);
				GameObject.Find ("MenuMusic").GetComponent<AudioSource> ().Play ();
				GameObject.Find ("MainMusic").GetComponent<AudioSource> ().Stop ();
			} 
			else
			{
				GetComponent<SpriteRenderer> ().color = Color.yellow;
				//If the new spawn is further on than the last
				if (zoneType != TYPE.CHECKPOINT) {
					LevelData.currentCheckPoint = checkPointNumber;
				}

			}
		}
	}
}
