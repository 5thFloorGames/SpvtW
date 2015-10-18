using UnityEngine;
using System.Collections;

public class LoseBoxScript : MonoBehaviour {

	public LevelEnd gameOver;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag.Equals ("Enemy")) {
			gameOver.Enable();
		}
	}
}
