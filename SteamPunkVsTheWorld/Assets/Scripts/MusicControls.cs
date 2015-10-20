using UnityEngine;
using System.Collections;

public class MusicControls : MonoBehaviour {

	private AudioSource[] audios;
	private AudioSource music;

    void Awake() {
		DontDestroyOnLoad(transform.gameObject);
		audios = gameObject.GetComponents<AudioSource>();
        music = audios[0];
    }

    void OnLevelWasLoaded(int level) {
        if ((level == 0)) {
            music.Stop();
        }
        if (level == 1 && !music.isPlaying) {
            music.Play();
        }
    }

	public void playMenuSound(bool audio) {
		// just to make it not go over the max index
		if (audio) {
			audios [1].PlayOneShot (audios [1].clip);
		} else {
			audios [2].PlayOneShot (audios [2].clip);
		}
	}
}