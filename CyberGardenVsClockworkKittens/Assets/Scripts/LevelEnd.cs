using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {

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
        SceneManager.LoadScene("Menu");
    }

	IEnumerator waitaMomentAndResetLevel() {
		yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Game");
    }
}
