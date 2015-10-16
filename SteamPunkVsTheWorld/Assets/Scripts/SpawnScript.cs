using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject enemy;
	public int orderInLayer;
	private GameLogic logic;

	// Use this for initialization
	void Start () {
		logic = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameLogic>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Spawn(){
		//print ("spawning at " + (transform.position));
		GameObject spawned = (GameObject) Instantiate (enemy, transform.position, Quaternion.identity);
		spawned.GetComponentInChildren<SpriteRenderer> ().sortingOrder = orderInLayer;
		logic.registerEnemy (spawned);
	}


}
