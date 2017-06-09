using UnityEngine;
using System.Collections;

public class SelfDestruction : MonoBehaviour {

	public float timeUntilDestruction = 1f;

	// Use this for initialization
	void Start () {
		Invoke("SelfDestruct", timeUntilDestruction);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SelfDestruct(){
		Destroy (gameObject);
	}
}
