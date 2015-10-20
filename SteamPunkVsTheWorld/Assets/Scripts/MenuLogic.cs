using UnityEngine;
using System.Collections;

public class MenuLogic : MonoBehaviour {
	private GameObject musicObject;
	private AudioSource hoverSound;

	void Start () {
        checkMusic();
		hoverSound = gameObject.AddComponent<AudioSource>();
		hoverSound.playOnAwake = false;
		hoverSound.volume = 0.05f;
		hoverSound.clip = Resources.Load("hoverSound") as AudioClip;
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

	public void playSoundOnHover() {
		hoverSound.Play ();
	}

    public void loadScene(int level) {
		StartCoroutine(playChoosingSoundAndLoadGame(level));
    }

    public void exitGame() {
		StartCoroutine(playExitSoundAndExit());
    }

	IEnumerator playExitSoundAndExit() {
		musicObject.GetComponent<MusicControls> ().playMenuSound (false);
		yield return new WaitForSeconds(0.5f);
		Application.Quit();
	}

	IEnumerator playChoosingSoundAndLoadGame(int level) {
		musicObject.GetComponent<MusicControls> ().playMenuSound (true);
		yield return new WaitForSeconds(0.5f);
		Application.LoadLevel(level);
	}
}
