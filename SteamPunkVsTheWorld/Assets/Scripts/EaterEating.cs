using UnityEngine;
using System.Collections;

public class EaterEating : MonoBehaviour {

	public bool digesting = false;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag.Equals("Enemy")){
			digesting = true;
			Destroy(other.gameObject);
			Invoke("Digested", 40);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void Digested(){
		digesting = false;
	}
}
