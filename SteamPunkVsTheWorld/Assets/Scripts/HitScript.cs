using UnityEngine;
using System.Collections;

public class HitScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag.Equals ("Enemy")) {
			other.SendMessageUpwards ("Damaged");
			GameObject hit = (GameObject)Instantiate(Resources.Load("HitEffect"));
			hit.transform.position = gameObject.transform.position;
			hit.transform.Translate (new Vector3(0, 0.37f, 0));
			Destroy(gameObject);
		}
	}
}
