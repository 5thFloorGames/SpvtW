using UnityEngine;
using System.Collections;

public class GameMenuSounds : MonoBehaviour {
	private AudioSource[] audios;
	
	void Start () {
		audios = gameObject.GetComponents<AudioSource>();
	}

	void Update () {
		
	}

}
