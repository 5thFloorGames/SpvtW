using UnityEngine;
using System.Collections;

public class LoseBoxScript : MonoBehaviour {

	public LevelEnd gameOver;
	private GameLogic logic;

	// Use this for initialization
	void Start () {
		logic = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLogic>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag.Equals ("Enemy")) {
			logic.TurnOffButtons();
			gameOver.Enable();
		}
	}
}
