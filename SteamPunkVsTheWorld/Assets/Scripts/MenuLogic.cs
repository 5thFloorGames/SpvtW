using UnityEngine;
using System.Collections;

public class MenuLogic : MonoBehaviour {
	private GameObject musicObject;

	void Start () {
        checkMusic();
    }

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            Application.LoadLevel(1);
        }
    }

    void checkMusic() {
        musicObject = GameObject.Find("MusicControls");
        if (musicObject == null) {
            musicObject = Instantiate<GameObject>((GameObject)Resources.Load("MusicControls"));
            musicObject.name = "MusicControls";
        }
    }

    public void loadScene(int level) {
		musicObject.GetComponent<MusicControls> ().playMenuSound (true);
        Application.LoadLevel(level);
    }

    public void exitGame() {
		StartCoroutine(playExitSoundAndExit());
        
    }

	IEnumerator playExitSoundAndExit() {
		musicObject.GetComponent<MusicControls> ().playMenuSound (false);
		yield return new WaitForSeconds(0.5f);
		Application.Quit();
	}
}
