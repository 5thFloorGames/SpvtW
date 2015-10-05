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
				free = false;
				logic.ChangePlant("None");
			}
		}

		print ("clicked");
		//this.gameObject.GetComponent<Renderer> ().material.color = Color.green;
		//print ("stuff");

	}
}
