using UnityEngine;
using System.Collections;

public class SelfDestruction : MonoBehaviour {

	public float timeUntilDestruction = 1f;
	
	void Start () {
		Invoke("SelfDestruct", timeUntilDestruction);
	}

	void SelfDestruct(){
		Destroy (gameObject);
	}
}
