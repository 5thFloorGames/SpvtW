using UnityEngine;
using System.Collections;

public class ClickToBuild : MonoBehaviour {

	public bool free = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		if (free) {
			Instantiate(GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLogic>().activePlant(), transform.position, Quaternion.identity);
			free = false;
		}

		print ("clicked");
		//this.gameObject.GetComponent<Renderer> ().material.color = Color.green;
		//print ("stuff");

	}
}
