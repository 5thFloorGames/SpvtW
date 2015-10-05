﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour {

	public List<GameObject> plants;
	public Plant active;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangePlant (string plantName){
		active = (Plant) System.Enum.Parse( typeof( Plant ), plantName );
	}

	public GameObject buildPlant(){
		if (active != Plant.None) {
			Resources.buyPlant (active);
			return plants[(int)active];
		} else {
			return null;
		}
	}
}
