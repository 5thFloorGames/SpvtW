﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnDirector : MonoBehaviour {

	List<SpawnScript> spawners = new List<SpawnScript>();
	private int[] spawnAmounts = {1,1,1,2,2,2,3,3,3,0,10};
	private Queue<int> spawnQueue;
	private int spawnIndex = 0;

	// Use this for initialization
	void Start () {
		foreach(SpawnScript s in GameObject.FindObjectsOfType<SpawnScript> ()){
			spawners.Add(s);
		}
		InvokeRepeating("nextSpawn", 15, 15);
		setSpawnQueue (28);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void nextSpawn(){
		Spawn (spawnAmounts[spawnIndex]);
		spawnIndex++;
		if (spawnIndex == spawnAmounts.Length) {
			CancelInvoke();
		}
	}

	void Spawn(int amount){
		for (int i = 0; i < amount; i++) {
			spawners[spawnQueue.Dequeue()].Spawn();
		}
	}

	void setSpawnQueue(int length){
		Queue<int> tempQueue = new Queue<int>();
		for (int i = 0; i < length; i++) {
			tempQueue.Enqueue(Random.Range(0,5));
		}
		spawnQueue = tempQueue;
	}
}