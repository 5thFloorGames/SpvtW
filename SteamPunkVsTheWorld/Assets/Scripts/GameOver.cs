﻿using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Enable(){
		gameObject.SetActive (true);
	}

	public void Restart(){
		Application.LoadLevel(1);
	}
}