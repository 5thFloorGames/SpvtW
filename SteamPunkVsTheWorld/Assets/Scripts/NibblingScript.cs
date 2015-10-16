using UnityEngine;
using System.Collections;

public class NibblingScript : MonoBehaviour {

	public int health = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag.Equals ("Enemy")) {
			other.gameObject.SendMessage("Stop");
			health--;
			if (health == 0) {
				// Figure out how to enable two kittens that are stuck on the plant
				other.gameObject.SendMessage("Go");
				transform.parent.SendMessage("Free");
				if(tag.Equals("Shooter")){
					GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLogic>().unregisterShooter(gameObject);
				}
				Destroy(gameObject);
			}
		}
	}
}
