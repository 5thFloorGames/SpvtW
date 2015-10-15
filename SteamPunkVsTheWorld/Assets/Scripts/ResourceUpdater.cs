using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourceUpdater : MonoBehaviour {

	private Text[] resourceTexts;
	GameObject resourceCloud;

	// Use this for initialization
	void Start () {
		resourceTexts = gameObject.GetComponentsInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		foreach (Text textComponent in resourceTexts) {
			textComponent.text = ResourceScript.getResources().ToString();
		}
	}
}
