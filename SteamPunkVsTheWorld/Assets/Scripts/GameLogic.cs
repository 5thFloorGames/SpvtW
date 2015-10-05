using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour {

	public List<GameObject> plants;
	private Plant active;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangePlant(Plant plant){
		active = plant;
	}

	public GameObject activePlant(){
		return plants[(int)active];
	}
}
