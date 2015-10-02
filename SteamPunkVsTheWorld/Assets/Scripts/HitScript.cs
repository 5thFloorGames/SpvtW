using UnityEngine;
using System.Collections;

public class HitScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		print ("triggered");
		if (other.gameObject.tag.Equals ("Enemy")) {
			other.SendMessageUpwards ("Damaged");
			Destroy(gameObject);
		}
	}
}
