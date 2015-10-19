﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnDirector : MonoBehaviour {

	List<SpawnScript> spawners = new List<SpawnScript>();
	private int[] spawnAmounts = {1,1,1,2,2,2,3,3,3,0,10};
	private int[] spawnAmountsHugeLevel = {1,1,1,2,2,2,3,3,3,0,10,4,4,5,5,5,6,6,6,7,0,17};
	private Queue<int> spawnQueue;
	private int spawnIndex = 0;
	private bool waveDone = false;
	public LightSweepScript lightSweeper;

	// Use this for initialization
	void Start () {
		foreach(SpawnScript s in GameObject.FindObjectsOfType<SpawnScript> ()){
			spawners.Add(s);
		}
		//spawnAmounts = spawnAmountsHugeLevel;

		InvokeRepeating("nextSpawn", 0, 17);
		setSpawnQueue (countSpawns());


		print ("Spawnqueue: " + spawnQueue.Count);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void nextSpawn(){
		if (spawnIndex == spawnAmounts.Length) {
			print ("stopping");
			Invoke("stopSpawning",15);
			waveDone = true;
		} else {
			Spawn (spawnAmounts[spawnIndex]);
			spawnIndex++;
		}
	}

	void Spawn(int amount){
		float cumulate = 1f;
		if (amount != 0) {
			lightSweeper.Sweep ();
		}
		for (int i = 0; i < amount; i++) {
			Invoke("DelayedSpawn", cumulate);
			cumulate += Random.Range(0.2f, 1.5f);
		}
	}

	void DelayedSpawn(){
		//print (spawnQueue.Count);
		spawners[spawnQueue.Dequeue()].Spawn();
	}

	int countSpawns(){
		int amount = 0;
		for (int i = 0; i < spawnAmounts.Length; i++) {
			amount += spawnAmounts[i];
		}
		return amount;
	}

	void setSpawnQueue(int length){
		Queue<int> tempQueue = new Queue<int>();
		int twoBefore = -1;
		int	oneBefore = -1;
		for (int i = 0; i < length; i++) {
			int randomNumber = Random.Range(0,5);
			while(randomNumber == twoBefore || randomNumber == oneBefore){
				randomNumber = Random.Range(0,5);
			}
			tempQueue.Enqueue(randomNumber);
			twoBefore = oneBefore;
			oneBefore = randomNumber;
		}
		spawnQueue = tempQueue;
	}

	void printQueue(){
		while (spawnQueue.Count != 0) {
			print (spawnQueue.Dequeue());
		}
	}

	void stopSpawning(){
		CancelInvoke();
	}

	public bool noMoreEnemies(){
		return waveDone;
	}
}
