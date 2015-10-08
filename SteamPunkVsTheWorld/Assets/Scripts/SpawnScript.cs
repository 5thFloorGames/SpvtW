using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject enemy;
	public int orderInLayer;

	// Use this for initialization
	void Start () {
		Spawn ();
		InvokeRepeating("Spawn", Random.Range(10,60), 30);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Spawn(){
		GameObject spawned = (GameObject) Instantiate (enemy, transform.position + Vector3.left, Quaternion.identity);
		spawned.GetComponent<SpriteRenderer> ().sortingOrder = orderInLayer;
	}


}
