using UnityEngine;
using System.Collections;

public class ClickToBuild : MonoBehaviour {

	public bool free = true;
	private GameLogic logic;

	// Use this for initialization
	void Start () {
		logic = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameLogic>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		if (free) {
			GameObject thingTobuild = logic.buildPlant();
			if(thingTobuild != null){
				GameObject newPlant = (GameObject)Instantiate(thingTobuild, transform.position, Quaternion.identity);
				newPlant.transform.parent = transform;
				// Set order in layer according to the zombies and another plants 2,4,6,8,10 or something
				// Put the plants on the same layer as kittens
				free = false;
				logic.ChangePlant("None");
			}
		}

		//this.gameObject.GetComponent<Renderer> ().material.color = Color.green;
		//print ("stuff");

	}

	void OnMouseOver(){
		// show gray preview
	}

	void OnMouseExit(){
		// remove gray preview
	}

	void Free(){
		free = true;
	}
}
