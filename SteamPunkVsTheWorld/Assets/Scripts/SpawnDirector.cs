using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnDirector : MonoBehaviour {

	List<SpawnScript> spawners = new List<SpawnScript>();
	private List<int[]> levelSpawns = new List<int[]>();
	private Queue<int> spawnQueue;
	private int spawnIndex = 0;
	private bool waveDone = false;
	private int[] spawnList;
	public LightSweepScript lightSweeper;

	// Use this for initialization
	void Start () {
		foreach(SpawnScript s in GameObject.FindObjectsOfType<SpawnScript> ()){
			spawners.Add(s);
		}
		//spawnAmounts = spawnAmountsHugeLevel;
		int[] spawnAmounts = {1,1,1,2,2,2,3,3,3,0,10};
		int[] spawnAmountsHugeLevel = {1,1,1,2,2,2,3,3,3,0,10,4,4,5,5,5,6,6,6,7,0,17};
		levelSpawns.Add (spawnAmounts);
		levelSpawns.Add (spawnAmountsHugeLevel);

		spawnList = levelSpawns [GameState.level];
			
		InvokeRepeating("nextSpawn", 17, 17);
		setSpawnQueue (countSpawns());


		print ("Spawnqueue: " + spawnQueue.Count);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void nextSpawn(){
		if (spawnIndex == spawnList.Length) {
			Invoke("stopSpawning",15);
			waveDone = true;
		} else {
			Spawn (spawnList[spawnIndex]);
			spawnIndex++;
		}
	}

	void Spawn(int amount){
		float cumulate = 1f;
		if (amount != 0) {
			lightSweeper.Sweep ();
		}
		int partyLimit = amount / 2;
		for (int i = 0; i < partyLimit; i++) {
			if(Random.Range(0,3) == 0){
				Invoke("DelayedPartySpawn", cumulate);
				cumulate += Random.Range(0.2f, 1.5f);
				amount -= 2;
			}
		}
		for (int i = 0; i < amount; i++) {
			Invoke("DelayedSpawn", cumulate);
			cumulate += Random.Range(0.2f, 1.5f);
		}
	}

	void DelayedSpawn(){
		//print (spawnQueue.Count);
		spawners [spawnQueue.Dequeue ()].Spawn ();
	}

	void DelayedPartySpawn(){
		//print (spawnQueue.Count);
		spawners [spawnQueue.Dequeue ()].PartySpawn ();
	}

	int countSpawns(){
		int amount = 0;
		for (int i = 0; i < spawnList.Length; i++) {
			amount += spawnList[i];
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
