using UnityEngine;
using System.Collections;

public class EnergySpawnScript : MonoBehaviour {

	public GameObject energy;
	
	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn", 6, 6);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void Spawn(){
		Instantiate (energy, transform.position + Vector3.down, Quaternion.identity);
	}
}
