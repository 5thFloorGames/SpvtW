using UnityEngine;
using System.Collections;

public class LevelEnd : MonoBehaviour {
	
	void Start () {
	
	}

	void Update () {
	
	}

	public void Enable(){
		gameObject.SetActive (true);
	}

	public void Restart(){
		if (GameState.level == GameState.maxLevel) {
			Application.LoadLevel (0);
		} else {
			Application.LoadLevel (1);
		}
	}

	public void ExitToMenu() {
		Application.LoadLevel (0);
	}
}
