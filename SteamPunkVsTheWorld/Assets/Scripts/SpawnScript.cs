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
		GameObject spawned = (GameObject) Instantiate (enemy, transform.position + Vector3.left, Quaternion.identity);
		spawned.GetComponentInChildren<SpriteRenderer> ().sortingOrder = orderInLayer;
	}


}
