using UnityEngine;
using System.Collections;

public class LoseBoxScript : MonoBehaviour {

	public LevelEnd gameOver;
	private GameLogic logic;
	
	void Start () {
		logic = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLogic>();
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag.Equals ("Enemy")) {
			logic.TurnOffButtons();
			gameOver.Enable();
		}
	}
}
