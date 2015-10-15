using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ParentButtonInteractableCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.GetComponentInParent<Button>().interactable) {

		}
	}
}
