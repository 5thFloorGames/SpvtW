using UnityEngine;
using System.Collections;

public class GlobalResourceSpawner : MonoBehaviour {

	public GameObject energy;
	
	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn", 6, 6);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void Spawn(){
        GameObject spawned = (GameObject)Instantiate (energy, transform.position + Vector3.down, Quaternion.identity);
        ResourceObjectLogic cfr = spawned.GetComponent<ResourceObjectLogic>();
        if (gameObject.tag != "Plant") {
            cfr.globalResource = true;
        } else {
            cfr.globalResource = false;
        }
	}
}
