using UnityEngine;
using System.Collections;

public class ClickForResource : MonoBehaviour {

	private GameObject logic; 

	// Use this for initialization
	void Start () {
		logic = GameObject.FindGameObjectWithTag ("GameController");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		Resources.addResources (25);
		Destroy (gameObject);
	}
}
