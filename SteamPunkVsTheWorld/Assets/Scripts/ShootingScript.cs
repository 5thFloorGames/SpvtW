using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {

	public GameObject bullet;
	public int orderInLayer;
	private bool shooting = false;

	// Use this for initialization
	void Start () {
		orderInLayer = gameObject.GetComponentInChildren<SpriteRenderer> ().sortingOrder + 2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Shoot() {
		GameObject tempBullet = (GameObject) Instantiate (bullet,transform.position + Vector3.right, Quaternion.identity);
		tempBullet.GetComponentInChildren<SpriteRenderer> ().sortingOrder = orderInLayer;
	}

	void StartShooting() {
		if (!shooting) {
			InvokeRepeating("Shoot", 1.6f, 1.6f);
			shooting = true;
		}
	}

	void Stop(){
		if (shooting) {
			CancelInvoke ();
			shooting = false;
		}
	}
}
