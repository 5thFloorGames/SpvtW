using UnityEngine;
using System.Collections;

public class ResourceGeneration : MonoBehaviour {

	public GameObject resource;
	
	// Use this for initialization
	void Start () {
		InvokeRepeating("Produce", 3, 10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void Produce() {
		Instantiate (resource, transform.position, Quaternion.identity);
	}
}