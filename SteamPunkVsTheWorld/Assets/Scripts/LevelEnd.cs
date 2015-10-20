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
		Application.LoadLevel (1);
	}

	public void ExitToMenu() {
		GameState.reset();
		Application.LoadLevel (0);
	}
}
