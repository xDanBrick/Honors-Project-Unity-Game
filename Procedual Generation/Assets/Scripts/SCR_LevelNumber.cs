using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SCR_LevelNumber : MonoBehaviour {

	private int pageNumber = 0;
	[SerializeField]private GameObject rightArrow;
	[SerializeField]private GameObject leftArrow;
	[SerializeField]private GameObject pageMarker;
	// Use this for initialization
	void Start () {
		SetLevelNumbers ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void ChangePage(int increment)
	{
		pageNumber += increment;
		pageMarker.transform.Translate (50 * increment, 0, 0);
		SetLevelNumbers ();
	}

	public void SetPage(int index)
	{
		pageNumber = index;
		SetLevelNumbers ();
	}

	private void SetLevelNumbers()
	{
		if (pageNumber == 0) {
			leftArrow.GetComponent<Button> ().interactable = false;
		} 
		else 
		{
			leftArrow.GetComponent<Button> ().interactable = true;
		}

		if (pageNumber == 4) 
		{
			rightArrow.GetComponent<Button> ().interactable = false;
		} 
		else
		{
			rightArrow.GetComponent<Button> ().interactable = true;
		}


		for (int i = 0; i < transform.childCount; i++) {
			int levelNumber = (15 * pageNumber) + (i + 1);
			transform.GetChild (i).GetComponent<SCR_LevelButton> ().SetNumber (levelNumber);
		}
	}
}
