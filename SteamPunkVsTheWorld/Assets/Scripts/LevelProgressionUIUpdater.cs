using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelProgressionUIUpdater : MonoBehaviour {
	private Image levelProgress;
	
	void Start () {
		levelProgress = gameObject.GetComponent<Image>();
	}

	void Update () {

	}

	public void updateProgressBar (float progressStatus) {
		levelProgress.fillAmount = progressStatus;
	}
}
