﻿using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	private GameObject cat;
	public int orderInLayer;
	private GameLogic logic;
	
	void Start () {
		logic = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameLogic>();
		cat = (GameObject) Resources.Load("Cat");
	}

	private void Spawn(bool hat, int health, bool runner){
		GameObject spawned = (GameObject) Instantiate (cat, transform.position, Quaternion.identity);
		CatMove catFeatures = spawned.GetComponent<CatMove> ();
		catFeatures.hasHat = hat;
		catFeatures.isRunner = runner;
		catFeatures.maxHealth = health;
		spawned.GetComponentInChildren<SpriteRenderer> ().sortingOrder = orderInLayer;
		logic.registerEnemy (spawned);
	}

	public void Spawn() {
		Spawn (false, 13, false);
	}

	public void PartySpawn() {
		Spawn (true, 26, false);
	}

	public void RunnerSpawn() {
		Spawn (false, 13, true);
	}

	public void PartyRunnerSpawn() {
		Spawn (true, 26, true);
	}

}
