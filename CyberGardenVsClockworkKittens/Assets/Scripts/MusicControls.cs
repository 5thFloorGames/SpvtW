using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicControls : MonoBehaviour {

	private AudioSource[] audios;
	private AudioSource music;

    void Awake() {
		DontDestroyOnLoad(transform.gameObject);
		audios = gameObject.GetComponents<AudioSource>();
        music = audios[0];
    }


    public void playMenuSound(bool audio) {
		if (audio) {
			audios [1].PlayOneShot (audios [1].clip);
		} else {
			audios [2].PlayOneShot (audios [2].clip);
		}
	}

    void OnEnable() {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable() {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
        if ((scene.name == "Menu")) {
            music.Stop();
        }
        if (scene.name == "Game" && !music.isPlaying) {
            music.Play();
        }
    }
}