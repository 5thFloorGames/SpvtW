using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonHandling : MonoBehaviour {

	public Plant plant;
	public float cooldown = 5f;
	private Button button;
	private float timeStamp = 0;
	public bool cooldownOnStart = true;

	// Use this for initialization
	void Start () {
		button = gameObject.GetComponent<Button> ();
		if (cooldownOnStart) {
			ActivateCooldown ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (ResourceScript.getResources () < ResourceScript.getPlantPrice(plant) || timeStamp > Time.time) {
			button.interactable = false;
		} else {
			button.interactable = true;
		}
	}

	void ActivateCooldown(){
		timeStamp = Time.time + cooldown;
	}
}
