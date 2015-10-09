using UnityEngine;
using System.Collections;

public class ClickForResource : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		ResourceScript.addResources (25);
		Destroy (gameObject);
	}
}
