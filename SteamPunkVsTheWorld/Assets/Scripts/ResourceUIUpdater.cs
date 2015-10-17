using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourceUIUpdater : MonoBehaviour {

	private Text[] resourceTexts;
	private GameObject resourceCloud;
    private int previousResources;
    public int maxSize = 400;

	// Use this for initialization
	void Start () {
        previousResources = 99;
		resourceTexts = gameObject.GetComponentsInChildren<Text>();
        resourceCloud = transform.FindChild("ResourceCloud").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        int resources = ResourceManager.getResources();
        if (resources != previousResources) {
            string resourceText = resources.ToString();
            foreach (Text textComponent in resourceTexts) {
                textComponent.text = resourceText;
            }

            int cloudSize = resources * 10;
            if (cloudSize > 500) {
                cloudSize = 500;
            }
            resourceCloud.transform.localScale = new Vector3(cloudSize, cloudSize, 1);
            previousResources = resources;
        }
	}
}
