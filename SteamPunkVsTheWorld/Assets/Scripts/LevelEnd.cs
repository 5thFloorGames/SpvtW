﻿using UnityEngine;
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
		StartCoroutine(waitaMomentAndResetLevel());
	}

	public void ExitToMenu() {
		StartCoroutine(waitaMomentAndExitToMenu());
	}

	IEnumerator waitaMomentAndExitToMenu() {
		yield return new WaitForSeconds(0.5f);
		GameState.reset();
		Application.LoadLevel (0);
	}

	IEnumerator waitaMomentAndResetLevel() {
		yield return new WaitForSeconds(0.5f);
		Application.LoadLevel (1);
	}
}
