using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	private GameObject normalCat;
	private GameObject partyCat;
	public int orderInLayer;
	private GameLogic logic;

	// Use this for initialization
	void Start () {
		logic = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameLogic>();
		normalCat = (GameObject) Resources.Load("Cat");
		partyCat = (GameObject) Resources.Load("PartyCat");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Spawn(){
		//print ("spawning at " + (transform.position));
		GameObject spawned = (GameObject) Instantiate (normalCat, transform.position, Quaternion.identity);
		spawned.GetComponentInChildren<SpriteRenderer> ().sortingOrder = orderInLayer;
		logic.registerEnemy (spawned);
	}

	public void PartySpawn(){
		//print ("spawning at " + (transform.position));
		GameObject spawned = (GameObject) Instantiate (partyCat, transform.position, Quaternion.identity);
		spawned.GetComponentInChildren<SpriteRenderer> ().sortingOrder = orderInLayer;
		logic.registerEnemy (spawned);
	}
	

}
