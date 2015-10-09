using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourceUpdater : MonoBehaviour {

	private Text resources;

	// Use this for initialization
	void Start () {
		resources = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		resources.text = ResourceScript.getResources().ToString();
	}
}
