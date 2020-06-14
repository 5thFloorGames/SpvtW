using UnityEngine;
using System.Collections;

public class DespawnScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
        Destroy(other.gameObject);
	}
}
