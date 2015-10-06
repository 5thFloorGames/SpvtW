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
				Instantiate(thingTobuild, transform.position, Quaternion.identity);
				// Save this so you can free the spot when a plant dies
				// Set planting spot as parent
				free = false;
				logic.ChangePlant("None");
			}
		}

		//this.gameObject.GetComponent<Renderer> ().material.color = Color.green;
		//print ("stuff");

	}
}
