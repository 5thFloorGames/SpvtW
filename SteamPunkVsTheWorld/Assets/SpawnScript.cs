using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject enemy;

	// Use this for initialization
	void Start () {
		Instantiate (enemy, transform.position + Vector3.left, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
