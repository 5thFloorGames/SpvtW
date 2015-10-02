using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour {

	public List<GameObject> plants;
	private int index = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangePlant(){
		index++;
		if (index >= plants.Count) {
			index = 0;
		}
	}

	public GameObject activePlant(){
		return plants[index];
	}
}
