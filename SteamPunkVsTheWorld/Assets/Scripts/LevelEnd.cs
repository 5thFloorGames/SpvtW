using UnityEngine;
using System.Collections;

public class LevelEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
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
}
