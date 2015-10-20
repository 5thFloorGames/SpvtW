using UnityEngine;
using System.Collections;

public class MusicControls : MonoBehaviour {
	
    public AudioClip music;
    private AudioSource source;
	
    void Awake() {
		DontDestroyOnLoad(transform.gameObject);
        source = GetComponent<AudioSource>();
    }

    void OnLevelWasLoaded(int level) {
        if ((level == 0)) {
            source.Stop();
        }
        if (level == 1) {
            source.clip = music;
            source.Play();
        }
    }
}
