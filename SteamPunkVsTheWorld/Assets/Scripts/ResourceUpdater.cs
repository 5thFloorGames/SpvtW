using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourceUpdater : MonoBehaviour {

	public Text resources;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		resources.text = ("Resources: " + Resources.getResources());
	}
}
