using UnityEngine;
using System.Collections;

public class NibblingScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionStay2D(Collision2D other) {
		print ("nomnom");
		if (other.gameObject.tag.Equals ("Enemy")) {
			this.SendMessage("Damaged");
		}
	}
}
