using UnityEngine;
using System.Collections;

public class NibblingScript : MonoBehaviour {

	public int health = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionStay2D(Collision2D other) {
		print ("nomnom");
		if (other.gameObject.tag.Equals ("Enemy")) {
			print ("damaged");
			health--;
			if (health == 0) {
				transform.parent.SendMessage("Free");
				Destroy(gameObject);
			}
		}
	}
}
