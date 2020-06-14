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
	public LevelProgressionUIUpdater levelprogress; 
	
	void Start () {
		foreach(SpawnScript s in GameObject.FindObjectsOfType<SpawnScript> ()){
			spawners.Add(s);
		}
		//spawnAmounts = spawnAmountsHugeLevel;
		int[] spawnAmounts = {1,1,1,2,2,2,3,3,3,0,10};
		int[] spawnAmountsHugeLevel = {1,1,1,2,2,2,3,3,3,0,10,4,4,5,5,5,6,6,6,7,0,17};

		levelSpawns.Add (spawnAmounts);
		levelSpawns.Add (spawnAmounts);
		levelSpawns.Add (spawnAmountsHugeLevel);

		spawnList = levelSpawns [GameState.level];
			
		InvokeRepeating("nextSpawn", 19, 19);
		setSpawnQueue (countSpawns());

		//print ("Spawnqueue: " + spawnQueue.Count);
	}

	void nextSpawn(){
		levelprogress.updateProgressBar(PercentDone());
		if (spawnIndex == spawnList.Length) {
			Invoke("StopSpawning",15);
			waveDone = true;
		} else {
			Spawn (spawnList[spawnIndex]);
			spawnIndex++;
		}
	}

	void Spawn(int amount){
		if (amount != 0) {
			lightSweeper.Sweep ();
		}

		if (GameState.level < 1) {
			NormalAndPartyCats (amount);
		} else {
			AllTheCats(amount);
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

	void DelayedRunnerSpawn(){
		//print (spawnQueue.Count);
		spawners [spawnQueue.Dequeue ()].RunnerSpawn ();
	}

	void DelayedPartyRunnerSpawn(){
		//print (spawnQueue.Count);
		spawners [spawnQueue.Dequeue ()].PartyRunnerSpawn ();
	}

	void NormalAndPartyCats (int amount){
		float cumulate = 1f;
		int partyLimit = amount / 2;
		for (int i = 0; i < partyLimit; i++) {
			if (Random.Range (0, 3) == 0) {
				Invoke ("DelayedPartySpawn", cumulate);
				cumulate += Random.Range (0.2f, 1.5f);
				amount -= 2;
			}
		}
		for (int i = 0; i < amount; i++) {
			Invoke ("DelayedSpawn", cumulate);
			cumulate += Random.Range (0.2f, 1.5f);
		}
	}

	void AllTheCats (int amount){
		float cumulate = 1f;
		int partyLimit = amount / 2;
		for (int i = 0; i < partyLimit; i++) {
			bool party = false;
			bool runner = false;
			if (Random.Range (0, 3) == 0) {
				party = true;
			}
			if (Random.Range (0, 3) == 0) {
				runner = true;
			}
			if(party && runner && amount > 3){
				Invoke ("DelayedPartyRunnerSpawn", cumulate);
				amount -= 3;
			} else if(party){
				Invoke ("DelayedPartySpawn", cumulate);
				cumulate += Random.Range (0.2f, 1.5f);
				amount -= 2;
			} else if(runner){
				Invoke ("DelayedRunnerSpawn", cumulate);
				cumulate += Random.Range (0.2f, 1.5f);
				amount -= 2;
			}
		}
		for (int i = 0; i < amount; i++) {
			Invoke ("DelayedSpawn", cumulate);
			cumulate += Random.Range (0.2f, 1.5f);
		}
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

	void StopSpawning(){
		CancelInvoke();
	}

	public bool NoMoreEnemies(){
		return waveDone;
	}

	private float PercentDone(){
		return (float)(spawnIndex / (float)spawnList.Length);
	}
}
