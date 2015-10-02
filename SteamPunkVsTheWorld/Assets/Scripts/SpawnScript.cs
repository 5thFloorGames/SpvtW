using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject enemy;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn", Random.Range(1,20), 10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Spawn(){
		Instantiate (enemy, transform.position + Vector3.left, Quaternion.identity);
	}
}
