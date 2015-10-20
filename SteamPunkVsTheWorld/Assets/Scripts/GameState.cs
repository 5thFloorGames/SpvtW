using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	public static int level = 0;
	public static int maxLevel = 2;
	
	void Start () {
	
	}

	void Update () {
	
	}

	public static void levelUp(){
		level++;
		if (level > maxLevel) {
			level = maxLevel;
		}
	}

	public static bool gameWon () {
		return level == maxLevel;
	}
}
