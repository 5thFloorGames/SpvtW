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

	private void Spawn(bool hat, int health){
		GameObject spawned = (GameObject) Instantiate (cat, transform.position, Quaternion.identity);
		CatMove catFeatures = spawned.GetComponent<CatMove> ();
		catFeatures.hasHat = hat;
		catFeatures.maxHealth = health;
		spawned.GetComponentInChildren<SpriteRenderer> ().sortingOrder = orderInLayer;
		logic.registerEnemy (spawned);
	}

	public void Spawn(){
		Spawn (false, 13);
	}

	public void PartySpawn(){
		Spawn (true, 26);
	}
	

}
