using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourceUIUpdater : MonoBehaviour {

	private Text[] resourceTexts;
	private GameObject resourceCloud;
    private int previousResources;
    public int maxSize = 400;

	void Start () {
        previousResources = 99;
		resourceTexts = gameObject.GetComponentsInChildren<Text>();
        resourceCloud = transform.FindChild("ResourceCloud").gameObject;
	}

	void Update () {
        int resources = ResourceManager.getResources();
        if (resources != previousResources) {
            string resourceText = resources.ToString();
            foreach (Text textComponent in resourceTexts) {
                textComponent.text = resourceText;
            }

            int cloudSize = resources * 10;
            if (cloudSize > maxSize) {
                cloudSize = maxSize;
            }
            resourceCloud.transform.localScale = new Vector3(cloudSize, cloudSize, 1);
            previousResources = resources;
        }
	}
}
