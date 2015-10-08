using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonHandling : MonoBehaviour {

	public Plant plant;
	public Button button;
	public int cooldown;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Resources.getResources () < Resources.getPlantPrice(plant)) {
			button.interactable = false;
		} else {
			button.interactable = true;
		}
	}
}
