using UnityEngine;
using System.Collections;

public class GameMenuSounds : MonoBehaviour {
	private AudioSource[] audios;
	
	void Start () {
		audios = gameObject.GetComponents<AudioSource>();
	}

	void Update () {
		
	}

	public void playHoverSound() {
		audios [0].Play ();
	}

	public void playChoosingSound() {
		audios [1].Play ();
	}

	public void playExitSound() {
		audios [2].Play ();
	}

}
