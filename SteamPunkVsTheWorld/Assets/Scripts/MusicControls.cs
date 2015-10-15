using UnityEngine;
using System.Collections;

public class MusicControls : MonoBehaviour {

    public AudioClip menuMusic;
    public AudioClip gameMusic;
    private AudioSource source;

    // Use this for initialization
    void Awake() {
        source = GetComponent<AudioSource>();
    }

    void OnLevelWasLoaded(int level) {
        if (((level == 0)) && (source.clip != menuMusic)) {
            source.clip = menuMusic;
            //source.Play();
        }
        if ((level == 1) && (source.clip != gameMusic)) {
            source.clip = gameMusic;
            //source.Play();
        }
    }
}
