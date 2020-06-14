using UnityEngine;
using System.Collections;

public class GameMenuSounds : MonoBehaviour {
	private AudioSource[] audios;
	
	void Start () {
		audios = gameObject.GetComponents<AudioSource>();
	}

	public void playHoverSound() {
		audios[0].PlayOneShot(audios[0].clip);
	}

	public void playChoosingSound() {
		audios[1].PlayOneShot(audios[1].clip);
	}

	public void playExitSound() {
		audios[2].PlayOneShot(audios[2].clip);
	}

}
