using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject enemy;
	public int orderInLayer;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Spawn(){
		//print ("spawning at " + (transform.position));
		GameObject spawned = (GameObject) Instantiate (enemy, transform.position, Quaternion.identity);
		spawned.GetComponentInChildren<SpriteRenderer> ().sortingOrder = orderInLayer;
	}


}
