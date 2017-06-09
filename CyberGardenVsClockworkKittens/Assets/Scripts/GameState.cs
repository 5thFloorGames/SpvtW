using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	public static int level = 0;
	public static int maxLevel = 3;
	
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

	public static void reset(){
		level = 0;
	}
}
