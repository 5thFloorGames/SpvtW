using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {

	public GameObject bullet;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Shoot", 3, 4);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Shoot() {
		Instantiate (bullet,transform.position + Vector3.right, Quaternion.identity);
	}
}
