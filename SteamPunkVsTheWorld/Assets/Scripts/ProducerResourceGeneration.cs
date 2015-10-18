﻿using UnityEngine;
using System.Collections;

public class ProducerResourceGeneration : MonoBehaviour {

	public GameObject resource;
	public AudioSource energyProductionSound;
	
	// Use this for initialization
	void Start () {
		InvokeRepeating("Produce", 5, 24);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void Produce() {
		GameObject spawned = (GameObject)Instantiate (resource, transform.position + new Vector3(0f,0f,-1f), Quaternion.identity);
		energyProductionSound.PlayOneShot (energyProductionSound.clip);
		ResourceObjectLogic crf = spawned.GetComponent<ResourceObjectLogic>();
        crf.globalResource = false;
	}
}