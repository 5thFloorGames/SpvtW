﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour {

	private List<GameObject> plants;
	public List<Button> buttons;
	public Plant active;

	// Use this for initialization
	void Start () {
		plants = new List<GameObject>();
		plants.Add (new GameObject ());
		plants.Add (Resources.Load ("Producer"));
		plants.Add (Resources.Load ("Shooter"));
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
			buttons[(int)active].SendMessage("ActivateCooldown");
			return plants[(int)active];
		} else {
			return null;
		}
	}


}
