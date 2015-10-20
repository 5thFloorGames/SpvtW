using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelNumberHandler : MonoBehaviour {
	private string levelString;
	private Text levelText;
	
	void Start () {
		levelText = gameObject.GetComponent<Text> ();
		levelString = "";
		if (GameState.level == 0) {
			levelString += "Warm up";
		} else if (GameState.level == 1) {
			levelString += "1st";
		} else if (GameState.level == 2) {
			levelString += "2nd";
		} else if (GameState.level == 3) {
			levelString += "3rd";
		} else {
			levelString += GameState.level.ToString() + "th";
		}

		levelString += " level";
		levelText.text = levelString;
	}

	void Update () {
	
	}
}
