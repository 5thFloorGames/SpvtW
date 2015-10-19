using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	private GameObject cat;
	public int orderInLayer;
	private GameLogic logic;
	
	void Start () {
		logic = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameLogic>();
		cat = (GameObject) Resources.Load("Cat");
	}

	void Update () {
		
	}

	public void Spawn(){
		//print ("spawning at " + (transform.position));
		GameObject spawned = (GameObject) Instantiate (cat, transform.position, Quaternion.identity);
		spawned.GetComponent<CatMove> ().hasHat = false;
		spawned.GetComponent<CatMove> ().maxHealth = 13;
		spawned.GetComponentInChildren<SpriteRenderer> ().sortingOrder = orderInLayer;
		logic.registerEnemy (spawned);
	}

	public void PartySpawn(){
		//print ("spawning at " + (transform.position));
		GameObject spawned = (GameObject) Instantiate (cat, transform.position, Quaternion.identity);
		spawned.GetComponent<CatMove> ().hasHat = true;
		spawned.GetComponent<CatMove> ().maxHealth = 26;
		spawned.GetComponentInChildren<SpriteRenderer> ().sortingOrder = orderInLayer;
		logic.registerEnemy (spawned);
	}
	

}
