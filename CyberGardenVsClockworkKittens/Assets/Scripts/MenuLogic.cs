using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour {
    public GameObject mainOptions;
    public GameObject credits;
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
            SceneManager.LoadScene("Game");
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
		musicObject.GetComponent<MusicControls> ().playMenuSound (true);
        if (level == 0) {
            SceneManager.LoadScene("Menu");
        } else if (level == 1) {
            SceneManager.LoadScene("Game");
        }
    }

    public void exitGame() {
		StartCoroutine(playExitSoundAndExit());
    }

    public void showCredits() {
        playChoosingSound();
        mainOptions.SetActive(false);
        credits.SetActive(true);
    }

    public void showMainMenu() {
        playChoosingSound();
        mainOptions.SetActive(true);
        credits.SetActive(false);
    }

	IEnumerator playExitSoundAndExit() {
		musicObject.GetComponent<MusicControls> ().playMenuSound (false);
		yield return new WaitForSeconds(0.5f);
		Application.Quit();
	}

    void playChoosingSound() {
        musicObject.GetComponent<MusicControls>().playMenuSound(true);
    }

}
