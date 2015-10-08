using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonHandling : MonoBehaviour {

	public Plant plant;
	public Button button;
	public float cooldown = 5f;
	private float timeStamp = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Resources.getResources () < Resources.getPlantPrice(plant) || timeStamp > Time.time) {
			button.interactable = false;
		} else {
			button.interactable = true;
		}
	}

	void ActivateCooldown(){
		timeStamp = Time.time + cooldown;
	}
}
