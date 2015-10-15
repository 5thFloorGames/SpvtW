using UnityEngine;
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
		InvokeRepeating("nextSpawn", 1, 1);
		setSpawnQueue (28);
		print (spawners.Count + " spawners in scene");
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
}
