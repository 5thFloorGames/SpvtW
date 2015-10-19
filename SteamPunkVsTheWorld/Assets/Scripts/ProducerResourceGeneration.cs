using UnityEngine;
using System.Collections;

public class ProducerResourceGeneration : MonoBehaviour {
	private Animator animator;

	public GameObject resource;

	void Start () {
		InvokeRepeating("Produce", 5, 24);
		animator = gameObject.GetComponentInChildren<Animator>();
	}

	void Update () {
		
	}

	void StartProduction() {

	}
	
	void Produce() {
		animator.SetTrigger("LightUp");
		GameObject spawned = (GameObject)Instantiate (resource, transform.position + new Vector3(0f,0f,-1f), Quaternion.identity);
		ResourceObjectLogic crf = spawned.GetComponent<ResourceObjectLogic>();
        crf.globalResource = false;
	}
}