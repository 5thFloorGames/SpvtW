using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {

	public GameObject bullet;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Shoot", 1.6f, 1.6f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Shoot() {
		Instantiate (bullet,transform.position + Vector3.right, Quaternion.identity);
	}
}
