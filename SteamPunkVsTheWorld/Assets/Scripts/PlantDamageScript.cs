using UnityEngine;
using System.Collections;

public class PlantDamageScript : MonoBehaviour {

	public int health = 4;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Damaged(){
		health--;
		if (health == 0) {
			if(tag.Equals("Shooter")){
				GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLogic>().unregisterShooter(gameObject);
			}
			transform.parent.SendMessage("Free");
			Destroy(gameObject);
		}
	}
}
