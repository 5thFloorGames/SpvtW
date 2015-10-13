using UnityEngine;
using System.Collections;

public class DamageScript : MonoBehaviour {

	public int health = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Damaged(){
		health--;
		if (health == 0) {
			Destroy(gameObject);
		}
	}
}
