using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourceUpdater : MonoBehaviour {

	private Text[] resourceTexts;
	private GameObject resourceCloud;
    public int maxSize = 500;

	// Use this for initialization
	void Start () {
		resourceTexts = gameObject.GetComponentsInChildren<Text>();
        resourceCloud = transform.FindChild("ResourceCloud").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        int resources = ResourceScript.getResources();
        string resourceText = resources.ToString();
		foreach (Text textComponent in resourceTexts) {
            textComponent.text = resourceText;
		}

        int cloudSize = resources * 10;
        if (cloudSize > 500) {
            cloudSize = 500;
        }
        resourceCloud.transform.localScale = new Vector3(cloudSize, cloudSize, 1);
	}
}
